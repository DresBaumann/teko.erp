using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class GetLocationsQuery
{
	private readonly LocationRepository _locationRepository;

	public GetLocationsQuery(LocationRepository locationRepository)
	{
		_locationRepository = locationRepository;
	}

	public async Task<List<Location>> ExecuteAsync(int tenantId)
	{
		return await _locationRepository.GetLocations(tenantId);
	}
}