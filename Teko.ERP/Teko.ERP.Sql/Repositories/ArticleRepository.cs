using Microsoft.EntityFrameworkCore;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql.Repositories;

public class ArticleRepository
{
	private readonly ErpDbContext _dbContext;

	public ArticleRepository(ErpDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddArticle(Article article)
	{
		_dbContext.Articles.Add(article);

		await SaveAsync();
	}

	public async Task<List<Article>> GetAllArticles(int tenantId)
	{
		var articles = await _dbContext.Articles.Where(a => a.Tenant.Id == tenantId).ToListAsync();
		return articles;
	}

	public async Task SetStock(int locationId, int articleId, int quantity)
	{
		ArticleStock? articleStock =
			await _dbContext.ArticleStocks.SingleOrDefaultAsync(a =>
				a.Article.Id == articleId && a.Location.Id == locationId);

		if (articleStock != null)
		{
			articleStock.Stock = quantity;
		}

		await SaveAsync();
	}

	public async Task<List<(int ArticleId, int Price, string Category)>> GetAbcArticlesAsync(int tenantId)
	{
		var articlesData = await _dbContext.Sales
			.Where(s => s.Tenant.Id == tenantId).Include(s => s.ArticleSales)
			.ThenInclude(articleSale => articleSale.Article)
			.ToListAsync();

		var articleSales = articlesData
			.SelectMany(s => s.ArticleSales)
			.GroupBy(articleSale => articleSale.Article.Id)
			.Select(group => new
			{
				ArticleId = group.Key,
				TotalPrice = group.Sum(articleSale => articleSale.Quantity * articleSale.Article.Price),
				SaleCount = group.Count()
			})
			.ToList();

		var maxTotalPrice = articleSales.Max(articleSale => articleSale.TotalPrice);
		var maxSaleCount = articleSales.Max(articleSale => articleSale.SaleCount);

		var result = articleSales
			.Select(asData =>
			{
				var category = CalculateCategory(asData.TotalPrice, maxTotalPrice, asData.SaleCount, maxSaleCount);
				return (asData.ArticleId, asData.TotalPrice, category);
			})
			.ToList();

		return result;
	}

	public async Task<List<(int ArticleId, string ArticleName, int TotalRevenue)>>
		CalculateArticleTurnoverAsync(int tenantId)
	{
		var articlesData = await _dbContext.Sales
			.Where(s => s.Tenant.Id == tenantId).Include(s => s.ArticleSales)
			.ThenInclude(articleSale => articleSale.Article)
			.ToListAsync();

		var articleTurnover = articlesData
			.SelectMany(s => s.ArticleSales)
			.GroupBy(articleSale => articleSale.Article.Id)
			.Select(group => new
			{
				ArticleId = group.Key,
				ArticleName = group.First().Article.Name,
				TotalRevenue = group.Sum(articleSale => articleSale.Quantity * articleSale.Article.Price)
			})
			.ToList();

		var result = articleTurnover
			.Select(turnoverData =>
			{
				return (turnoverData.ArticleId, turnoverData.ArticleName, turnoverData.TotalRevenue);
			})
			.ToList();

		return result;
	}

	private string CalculateCategory(int totalPrice, int maxTotalPrice, int saleCount, int maxSaleCount)
	{
		var pricePercentage = (double)totalPrice / maxTotalPrice;
		var saleCountPercentage = (double)saleCount / maxSaleCount;

		if (pricePercentage >= 0.8 && saleCountPercentage >= 0.8)
			return "A";
		if (pricePercentage >= 0.5 && saleCountPercentage >= 0.5)
			return "B";
		return "C";
	}

	public async Task<List<ArticleStock?>> GetArticleStock(int tenantId)
	{
		return await _dbContext.ArticleStocks.Where(a => a.Article.Tenant.Id == tenantId).ToListAsync();
	}

	private async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}