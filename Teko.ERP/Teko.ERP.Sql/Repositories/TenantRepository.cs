using System.Collections.ObjectModel;
using Microsoft.EntityFrameworkCore;
using Microsoft.VisualBasic;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql.Repositories;

public class TenantRepository
{
	private readonly ErpDbContext _dbContext;

	public TenantRepository(ErpDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddTenant(Tenant tenant)
	{
		_dbContext.Tenants.Add(tenant);

		await SaveAsync();
	}

	public async Task<Tenant> GetTenant(int tenantId)
	{
		return await _dbContext.Tenants.SingleAsync(t => t.Id == tenantId);
	}

	public async Task<bool> ExistsTenant(int tenantId)
	{
		return await _dbContext.Tenants.AnyAsync(t => t.Id == tenantId);

		await SaveAsync();
	}

	public async Task<List<Tenant>> GetAllTenants()
	{
		return await _dbContext.Tenants.ToListAsync();
	}
	
	private async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}