using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Resources;
using Teko.ERP.Core.Storage.Commands;
using Teko.ERP.Core.Storage.Queries;
using Teko.ERP.Core.Tenant.Queries;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Api.Controllers
{
    [Route("api/[controller]")]
	[ApiController]
	public class StorageController : ControllerBase
	{
		private readonly CheckTenantExistsQuery _checkTenantExistsQuery;
		private readonly IsStorageModuleActivatedQuery _isStorageModuleActivatedQuery;

		public StorageController(CheckTenantExistsQuery checkTenantExistsQuery, IsStorageModuleActivatedQuery isStorageModuleActivatedQuery)
		{
			_checkTenantExistsQuery = checkTenantExistsQuery;
			_isStorageModuleActivatedQuery = isStorageModuleActivatedQuery;
		}

		[HttpGet]
		public async Task<ActionResult<List<Article>>> GetArticles([FromQuery] int tenantId, [FromServices] GetArticlesQuery query)
		{
			if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			{
				return BadRequest(ErrorResources.TenantNotFoundError);
			}
			return Ok(await query.ExecuteAsync(tenantId));
		}

		[HttpGet("Article/Stock")]
		public async Task<ActionResult<List<Article>>> GetStock([FromQuery] int tenantId, [FromServices] GetArticleStocksQuery query)
		{
			if (!await _isStorageModuleActivatedQuery.ExecuteAsync(tenantId))
			{
				return BadRequest(ErrorResources.StorageModuleNotActivated);
			}
			if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			{
				return BadRequest(ErrorResources.TenantNotFoundError);
			}
			return Ok(await query.ExecuteAsync(tenantId));
		}

		[HttpPost("Article")]
		public async Task<ActionResult> CreateArticle([FromBody] CreateArticleRequest request, [FromServices] CreateArticleCommand command)
		{
			if (!await _checkTenantExistsQuery.ExecuteAsync(request.TenantId))
			{
				return BadRequest(ErrorResources.TenantNotFoundError);
			}
			await command.ExecuteAsync(request);
			return Ok();
		}

		[HttpPut("Article/Stock")]
		public async Task<ActionResult> SetStock([FromBody] SetArticleStockRequest request, [FromServices] SetArticleStockCommand command)
		{
			await command.ExecuteAsync(request);
			return Ok();
		}

		[HttpGet("Article/Abc")]
		public async Task<ActionResult<List<(int ArticleId, int Price, string Category)>>> GetAbcList([FromQuery] int tenantId, [FromServices] GetAbcListQuery query)
		{
			if (!await _isStorageModuleActivatedQuery.ExecuteAsync(tenantId))
			{
				return BadRequest(ErrorResources.StorageModuleNotActivated);
			}
			if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			{
				return BadRequest(ErrorResources.TenantNotFoundError);
			}
			return Ok(await query.ExecuteAsync(tenantId));
		}
	}
}
