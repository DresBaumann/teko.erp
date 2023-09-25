using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class GetAbcListQuery
{
	private readonly ArticleRepository _articleRepository;

	public GetAbcListQuery(ArticleRepository articleRepository)
	{
		_articleRepository = articleRepository;
	}

	public async Task<List<(int ArticleId, int Price, string Category)>> ExecuteAsync(int tenantId)
	{
		return await _articleRepository.GetAbcArticlesAsync(tenantId);
	}
}