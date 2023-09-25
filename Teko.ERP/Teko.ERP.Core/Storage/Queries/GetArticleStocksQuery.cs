using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class GetArticleStocksQuery
{
	private readonly ArticleRepository _articleRepository;

	public GetArticleStocksQuery(ArticleRepository articleRepository)
	{
		_articleRepository = articleRepository;
	}

	public async Task<List<ArticleStock?>> ExecuteAsync(int tenantId)
	{
		return await _articleRepository.GetArticleStock(tenantId);
	}
}