using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Storage.Queries;

public class CheckLocationExistsQuery
{
	private readonly LocationRepository _locationRepository;

	public CheckLocationExistsQuery(LocationRepository locationRepository)
	{
		_locationRepository = locationRepository;
	}

	public async Task<bool> ExecuteAsync(int locationId)
	{
		return await _locationRepository.ExistsLocation(locationId);
	}
}