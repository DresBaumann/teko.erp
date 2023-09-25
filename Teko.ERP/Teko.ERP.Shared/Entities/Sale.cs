namespace Teko.ERP.Shared.Entities;

public class Sale
{
	public int Id { get; set; }

	public Debitor Debitor { get; set; }

	public List<ArticleSale> ArticleSales { get; set; }
	public int ReferenceNumber { get; set; }

	public ClaimState ClaimState { get; set; }

	public DateTime DueDate { get; set; }

	public Tenant Tenant { get; set; }
}