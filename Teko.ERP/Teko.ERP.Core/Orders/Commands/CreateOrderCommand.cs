using Teko.ERP.Shared.Entities;
using Teko.ERP.Sql.Repositories;

namespace Teko.ERP.Core.Orders.Commands;

public class CreateOrderCommand
{
    private readonly AccountRepository _accountRepository;

    private readonly TenantRepository _tenantRepository;

    public CreateOrderCommand(AccountRepository accountRepository, TenantRepository tenantRepository)
    {
        _accountRepository = accountRepository;
        _tenantRepository = tenantRepository;
    }

    public async Task ExecuteAsync(CreateOrderRequest request)
    {
        var tenant = await _tenantRepository.GetTenant(request.TenantId);
        var creditor = await _accountRepository.GetCreditor(request.CreditorId);
        await _accountRepository.AddOrder(new Order
        {
            ArticleOrders = request.ArticleOrders,
            ClaimState = request.ClaimState,
            ReferenceNumber = request.ReferenceNumber,
            DueDate = request.DueDate,
            Creditor = creditor,
            Tenant = tenant
        });
    }
}