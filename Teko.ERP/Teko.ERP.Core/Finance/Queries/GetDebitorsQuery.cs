using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Queries;

public class GetDebitorsQuery
{
	private readonly AccountRepository _accountRepository;

	public GetDebitorsQuery(AccountRepository accountRepository)
	{
		_accountRepository = accountRepository;
	}

	public async Task<List<Debitor>> ExecuteAsync(int tenantId)
	{
		return await _accountRepository.GetAllDebitors(tenantId);
	}
}