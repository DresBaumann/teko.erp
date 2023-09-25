using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Commands;

public class CreateCreditorCommand
{
	private readonly AccountRepository _accountRepository;

	private readonly TenantRepository _tenantRepository;

	public CreateCreditorCommand(AccountRepository accountRepository, TenantRepository tenantRepository)
	{
		_accountRepository = accountRepository;
		_tenantRepository = tenantRepository;
	}

	public async Task ExecuteAsync(CreateAccountRequest request)
	{
		var tenant = await _tenantRepository.GetTenant(request.TenantId);
		await _accountRepository.AddCreditor(new Creditor
		{
			FirstName = request.FirstName,
			LastName = request.LastName,
			City = request.City,
			PhoneNumber = request.PhoneNumber,
			Plz = request.Plz,
			Tenant = tenant
		});
	}
}