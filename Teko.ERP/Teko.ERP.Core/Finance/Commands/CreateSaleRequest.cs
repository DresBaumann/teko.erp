using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Core.Finance.Commands;

public class CreateSaleRequest
{
	public int TenantId { get; set; }
	public int DebitorId { get; set; }
	public List<ArticleSale> ArticleSales { get; set; }
	public int ReferenceNumber { get; set; }

	public ClaimState ClaimState { get; set; }

	public DateTime DueDate { get; set; }
}