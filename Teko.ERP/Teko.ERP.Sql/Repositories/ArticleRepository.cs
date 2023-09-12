using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
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

	public async Task<List<Article>> GetAllArticles()
	{
		List<Article> articles = await _dbContext.Articles.ToListAsync();
		return articles;
	}

	public async Task DeleteArticle(int id)
	{
		Article articleToDelete = _dbContext.Articles.SingleOrDefault(a => a.Id == id);

		if (articleToDelete != null)
		{
			_dbContext.Articles.Remove(articleToDelete);
			await SaveAsync();
		}
	}

	private async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}