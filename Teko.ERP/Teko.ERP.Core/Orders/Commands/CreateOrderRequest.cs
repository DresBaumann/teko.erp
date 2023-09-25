using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Core.Orders.Commands;

public class CreateOrderRequest
{
    public int TenantId { get; set; }
    public int CreditorId { get; set; }
    public List<ArticleOrder> ArticleOrders { get; set; }
    public int ReferenceNumber { get; set; }

    public ClaimState ClaimState { get; set; }

    public DateTime DueDate { get; set; }
}