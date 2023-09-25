using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class GetArticlesQuery
{
	private readonly ArticleRepository _repository;

	public GetArticlesQuery(ArticleRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<Article>> ExecuteAsync(int tenantId)
	{
		return await _repository.GetAllArticles(tenantId);
	}
}