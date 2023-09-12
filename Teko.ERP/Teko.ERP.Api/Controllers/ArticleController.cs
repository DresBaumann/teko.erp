using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Storage.Commands;
using Teko.ERP.Core.Storage.Queries;
using Teko.ERP.Shared.Entities;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Teko.ERP.Api.Controllers
{
	[Route("api/[controller]")]
	[ApiController]
	public class ArticleController : ControllerBase
	{
		// GET: api/<ArticleController>
		[HttpGet]
		public async Task<List<Article>> Get([FromServices] AllArticlesQuery query)
		{
			return await query.ExecuteAsync();
		}

		// GET api/<ArticleController>/5
		[HttpGet("{id}")]
		public string Get(int id)
		{
			return "value";
		}

		// POST api/<ArticleController>
		[HttpPost]
		public async Task Post([FromBody] CreateArticleRequest request, [FromServices] CreateArticleCommand command)
		{
			await command.ExecuteAsync(request);
		}

		// PUT api/<ArticleController>/5
		[HttpPut("{id}")]
		public void Put(int id, [FromBody] string value)
		{
		}

		// DELETE api/<ArticleController>/5
		[HttpDelete("{id}")]
		public void Delete(int id)
		{
		}
	}
}
