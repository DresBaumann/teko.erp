using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Finance.Commands;
using Teko.ERP.Core.Finance.Queries;
using Teko.ERP.Core.Resources;
using Teko.ERP.Core.Tenant.Queries;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class FinanceController : ControllerBase
{
	private readonly CheckTenantExistsQuery _checkTenantExistsQuery;

	public FinanceController(CheckTenantExistsQuery checkTenantExistsQuery)
	{
		_checkTenantExistsQuery = checkTenantExistsQuery;
	}

	[HttpGet("Debitor")]
	public async Task<ActionResult<List<Debitor>>> GetDebitors([FromQuery] int tenantId,
		[FromServices] GetDebitorsQuery query)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);
		return await query.ExecuteAsync(tenantId);
	}

	[HttpGet("Creditor")]
	public async Task<ActionResult<List<Creditor>>> GetCreditors([FromQuery] int tenantId,
		[FromServices] GetCreditorsQuery query)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);
		return await query.ExecuteAsync(tenantId);
	}

	[HttpPost("Creditor")]
	public async Task<ActionResult> AddCreditor([FromBody] CreateAccountRequest request,
		[FromServices] CreateCreditorCommand command)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(request.TenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);

		await command.ExecuteAsync(request);
		return Ok();
	}

	[HttpPost("Debitor")]
	public async Task<ActionResult> AddDebitor([FromBody] CreateAccountRequest request,
		[FromServices] CreateDebitorCommand command)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(request.TenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);

		await command.ExecuteAsync(request);
		return Ok();
	}

	[HttpGet("Turnover")]
	public async Task<ActionResult<List<(int ArticleId, string ArticleName, int TotalRevenue)>>> Get(int tenantId,
		[FromServices] GetArticleTurnoverQuery query)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);
		return Ok(await query.ExecuteAsync(tenantId));
	}

	[HttpGet("Debitors/Due")]
	public async Task<ActionResult<Dictionary<Debitor, List<Sale>>>> GetDueDebitors([FromQuery] int tenantId,
		[FromServices] GetDueDebitorsQuery query)
	{
		if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);
		return Ok(await query.ExecuteAsync(tenantId));
	}
}