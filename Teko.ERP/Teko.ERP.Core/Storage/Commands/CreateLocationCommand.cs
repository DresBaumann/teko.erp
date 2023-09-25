using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Commands;

public class CreateLocationCommand
{
	private readonly LocationRepository _locationRepository;
	private readonly TenantRepository _tenantRepository;

	public CreateLocationCommand(LocationRepository locationRepository, TenantRepository tenantRepository)
	{
		_locationRepository = locationRepository;
		_tenantRepository = tenantRepository;
	}

	public async Task ExecuteAsync(CreateLocationRequest request)
	{
		Shared.Entities.Tenant tenant = await _tenantRepository.GetTenant(request.TenantId);
		await _locationRepository.AddLocation(new Location
		{
			Name = request.Name,
			Description = request.Description,
			Address = request.Address,
			ArticleStocks = request.ArticleStocks,
			Tenant = tenant
		});
	}
}