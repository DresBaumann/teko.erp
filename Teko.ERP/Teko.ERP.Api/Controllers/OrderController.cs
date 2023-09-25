using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Orders.Commands;
using Teko.ERP.Core.Orders.Queries;
using Teko.ERP.Core.Resources;
using Teko.ERP.Core.Tenant.Queries;

namespace Teko.ERP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class OrderController : ControllerBase
{
	private readonly CheckTenantExistsQuery _checkTenantExistsQuery;
	private readonly IsOrderModuleActivatedQuery _isOrderModuleActivatedQuery;

	public OrderController(CheckTenantExistsQuery checkTenantExistsQuery,
		IsOrderModuleActivatedQuery isOrderModuleActivatedQuery)
	{
		_checkTenantExistsQuery = checkTenantExistsQuery;
		_isOrderModuleActivatedQuery = isOrderModuleActivatedQuery;
	}

	[HttpPost]
	public async Task<ActionResult> CreateOrder([FromBody] CreateOrderRequest request,
		[FromServices] CreateOrderCommand command)
	{
		if (!await _isOrderModuleActivatedQuery.ExecuteAsync(request.TenantId))
			return BadRequest(ErrorResources.OrderModuleNotActivated);
		if (!await _checkTenantExistsQuery.ExecuteAsync(request.TenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);

		await command.ExecuteAsync(request);
		return Ok();
	}

	[HttpGet]
	public async Task<ActionResult> GetOrders([FromQuery] int tenantId, [FromServices] GetOrdersQuery query)
	{
		if (!await _isOrderModuleActivatedQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.OrderModuleNotActivated);
		if (!await _checkTenantExistsQuery.ExecuteAsync(tenantId))
			return BadRequest(ErrorResources.TenantNotFoundError);

		await query.ExecuteAsync(tenantId);
		return Ok();
	}
}