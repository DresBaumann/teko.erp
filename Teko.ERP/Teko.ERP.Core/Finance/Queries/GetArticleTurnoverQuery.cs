using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Queries;

public class GetArticleTurnoverQuery
{
	private readonly ArticleRepository _articleRepository;

	public GetArticleTurnoverQuery(ArticleRepository articleRepository)
	{
		_articleRepository = articleRepository;
	}

	public async Task<List<(int ArticleId, string ArticleName, int TotalRevenue)>> ExecuteAsync(int tenantId)
	{
		return await _articleRepository.CalculateArticleTurnoverAsync(tenantId);
	}
}