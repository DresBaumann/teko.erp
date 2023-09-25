using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Queries;

public class GetCreditorsQuery
{
	private readonly AccountRepository _accountRepository;

	public GetCreditorsQuery(AccountRepository accountRepository)
	{
		_accountRepository = accountRepository;
	}

	public async Task<List<Creditor>> ExecuteAsync(int tenantId)
	{
		return await _accountRepository.GetAllCreditors(tenantId);
	}
}