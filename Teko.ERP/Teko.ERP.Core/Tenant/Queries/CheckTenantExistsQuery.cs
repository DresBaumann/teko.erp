using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Tenant.Queries;

public class CheckTenantExistsQuery
{
	private readonly TenantRepository _tenantRepository;

	public CheckTenantExistsQuery(TenantRepository tenantRepository)
	{
		_tenantRepository = tenantRepository;
	}

	public async Task<bool> ExecuteAsync(int tenantId)
	{
		return await _tenantRepository.ExistsTenant(tenantId);
	} 
}