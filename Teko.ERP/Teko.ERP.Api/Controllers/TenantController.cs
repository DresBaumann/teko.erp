using Microsoft.AspNetCore.Mvc;
using Teko.ERP.Core.Tenant.Commands;
using Teko.ERP.Core.Tenant.Queries;

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
	public async Task Post([FromServices] GetTenantsQuery query)
	{
		await query.ExecuteAsync();
	}
}