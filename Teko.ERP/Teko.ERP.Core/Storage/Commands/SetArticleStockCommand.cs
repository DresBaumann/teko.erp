using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Commands;

public class SetArticleStockCommand
{
	private readonly ArticleRepository _articleRepository;

	public SetArticleStockCommand(ArticleRepository articleRepository)
	{
		_articleRepository = articleRepository;
	}

	public async Task ExecuteAsync(SetArticleStockRequest request)
	{
		await _articleRepository.SetStock(request.LocationId, request.ArticleId, request.Quantity);
	}
}