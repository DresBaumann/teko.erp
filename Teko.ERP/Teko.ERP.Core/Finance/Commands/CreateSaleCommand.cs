using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Finance.Commands;

public class CreateSaleCommand
{
	private readonly AccountRepository _accountRepository;

	private readonly TenantRepository _tenantRepository;

	public CreateSaleCommand(AccountRepository accountRepository, TenantRepository tenantRepository)
	{
		_accountRepository = accountRepository;
		_tenantRepository = tenantRepository;
	}

	public async Task ExecuteAsync(CreateSaleRequest request)
	{
		var tenant = await _tenantRepository.GetTenant(request.TenantId);
		var debitor = await _accountRepository.GetDebitor(request.DebitorId);
		await _accountRepository.AddSale(new Sale
		{
			ArticleSales = request.ArticleSales,
			ClaimState = request.ClaimState,
			ReferenceNumber = request.ReferenceNumber,
			DueDate = request.DueDate,
			Debitor = debitor,
			Tenant = tenant
		});
	}
}