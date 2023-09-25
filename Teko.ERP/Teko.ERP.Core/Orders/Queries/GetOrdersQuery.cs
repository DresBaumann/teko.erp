using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Orders.Queries;

public class GetOrdersQuery
{
	private readonly AccountRepository _accountRepository;

	public GetOrdersQuery(AccountRepository accountRepository)
	{
		_accountRepository = accountRepository;
	}

	public async Task<List<Order>> ExecuteAsync(int tenantId)
	{
		return await _accountRepository.GetOrders(tenantId);
	}
}