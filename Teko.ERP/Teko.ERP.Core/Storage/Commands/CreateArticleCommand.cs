using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Commands;

public class CreateArticleCommand
{
	private readonly ArticleRepository _articleRepository;

	public CreateArticleCommand(ArticleRepository articleRepository)
	{
		_articleRepository = articleRepository;
	}

	public async Task ExecuteAsync(CreateArticleRequest request)
	{
		await _articleRepository.AddArticle(new Article
		{
			Name = request.Name,
			Price = request.Price,
			Description = request.Description
		});
	}
}