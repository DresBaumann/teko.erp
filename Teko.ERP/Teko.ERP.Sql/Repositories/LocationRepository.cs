using Microsoft.EntityFrameworkCore;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql.Repositories;

public class LocationRepository
{
	private readonly ErpDbContext _dbContext;

	public LocationRepository(ErpDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddLocation(Location location)
	{
		_dbContext.Locations.Add(location);
		await SaveAsync();
	}

	public async Task<bool> ExistsLocation(int locationId)
	{
		return await _dbContext.Locations.AnyAsync(t => t.Id == locationId);

		await SaveAsync();
	}

	public async Task<List<Location>> GetLocations(int tenantId)
	{
		return await _dbContext.Locations.Where(l => l.Tenant.Id == tenantId).ToListAsync();
	}

	private async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}