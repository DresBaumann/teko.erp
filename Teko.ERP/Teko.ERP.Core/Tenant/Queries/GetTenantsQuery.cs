using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Tenant.Queries;

public class GetTenantsQuery
{
	private readonly TenantRepository _tenantRepository;

	public GetTenantsQuery(TenantRepository tenantRepository)
	{
		_tenantRepository = tenantRepository;
	}
	public async Task<List<Shared.Entities.Tenant>> ExecuteAsync()
	{
		return await _tenantRepository.GetAllTenants();
	}
}