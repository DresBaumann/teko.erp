using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class AllArticlesQuery
{
	private readonly ArticleRepository _repository;

	public AllArticlesQuery(ArticleRepository repository)
	{
		_repository = repository;
	}

	public async Task<List<Article>> ExecuteAsync()
	{
		return await _repository.GetAllArticles();
	}
}