using Microsoft.EntityFrameworkCore;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql.Repositories;

public class AccountRepository
{
	private readonly ErpDbContext _dbContext;

	public AccountRepository(ErpDbContext dbContext)
	{
		_dbContext = dbContext;
	}

	public async Task AddCreditor(Creditor creditor)
	{
		_dbContext.Creditors.Add(creditor);

		await SaveAsync();
	}

	public async Task AddDebitor(Debitor debitor)
	{
		_dbContext.Debitors.Add(debitor);

		await SaveAsync();
	}

	public async Task AddSale(Sale sale)
	{
		_dbContext.Sales.Add(sale);

		await SaveAsync();
	}

	public async Task AddOrder(Order order)
	{
		_dbContext.Orders.Add(order);

		await SaveAsync();
	}

	public async Task<List<Debitor>> GetAllDebitors(int tenantId)
	{
		var debitors = await _dbContext.Debitors.Where(a => a.Tenant.Id == tenantId).ToListAsync();
		return debitors;
	}

	public async Task<List<Order>> GetOrders(int tenantId)
	{
		return await _dbContext.Orders.Where(a => a.Tenant.Id == tenantId).ToListAsync();
	}

	public async Task<List<Creditor>> GetAllCreditors(int tenantId)
	{
		var creditors = await _dbContext.Creditors.Where(a => a.Tenant.Id == tenantId).ToListAsync();
		return creditors;
	}

	public async Task<Debitor> GetDebitor(int debitorId)
	{
		return await _dbContext.Debitors.SingleAsync(d => d.Id == debitorId);
	}

	public async Task<Creditor> GetCreditor(int creditorId)
	{
		return await _dbContext.Creditors.SingleAsync(c => c.Id == creditorId);
	}


	public async Task<Dictionary<Debitor, List<Sale>>> GetDueSalesByDebitorAsync(int tenantId)
	{
		var currentDate = DateTime.Now;

		var dueSalesByDebitor = await _dbContext.Sales
			.Include(s => s.Debitor)
			.Where(s => s.ClaimState == ClaimState.Pending && s.DueDate <= currentDate && s.Tenant.Id == tenantId)
			.ToListAsync();

		var groupedSales = dueSalesByDebitor
			.GroupBy(s => s.Debitor)
			.ToDictionary(
				group => group.Key,
				group => group.ToList()
			);

		return groupedSales;
	}

	private async Task SaveAsync()
	{
		await _dbContext.SaveChangesAsync();
	}
}