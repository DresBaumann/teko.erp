using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Tenant.Queries;

public class IsOrderModuleActivatedQuery
{
	private readonly TenantRepository _tenantRepository;

	public IsOrderModuleActivatedQuery(TenantRepository tenantRepository)
	{
		_tenantRepository = tenantRepository;
	}

	public async Task<bool> ExecuteAsync(int tenantId)
	{
		var tenant = await _tenantRepository.GetTenant(tenantId);

		return tenant.OrderModuleActive;
	}
}