using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Tenant.Commands;

public class CreateTenantCommand
{
	private readonly TenantRepository _tenantRepository;

	public CreateTenantCommand(TenantRepository tenantRepository)
	{
		_tenantRepository = tenantRepository;
	}

	public async Task ExecuteAsync(CreateTenantRequest request)
	{
		await _tenantRepository.AddTenant(new Shared.Entities.Tenant
		{
			Name = request.Name, FinanceModuleActive = request.FinanceModuleActive, OrderModuleActive = request.OrderModuleActive, StorageModuleActive = request.StorageModuleActive
		});
	}
}