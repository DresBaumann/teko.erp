using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Tenant.Commands;
using Teko.ERP.Core.Tenant.Queries;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class TenantController : ControllerBase
{
	[HttpPost]
	public async Task Post([FromBody] CreateTenantRequest request, [FromServices] CreateTenantCommand command)
	{
		await command.ExecuteAsync(request);
	}

	[HttpGet]
	public async Task<List<Tenant>> Post([FromServices] GetTenantsQuery query)
	{
		return await query.ExecuteAsync();
	}
}