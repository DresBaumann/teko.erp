namespace Teko.ERP.Shared.Entities;

public class Order
{
	public int Id { get; set; }
	public Tenant Tenant { get; set; }
	public Creditor Creditor { get; set; }
	public List<ArticleOrder> ArticleOrders { get; set; }
	public int ReferenceNumber { get; set; }

	public ClaimState ClaimState { get; set; }

	public DateTime DueDate { get; set; }
}