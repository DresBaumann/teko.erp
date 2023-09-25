namespace Teko.ERP.Shared.Entities;

public class ArticleSale
{
	public int Id { get; set; }
	public Article Article { get; set; }
	public int Quantity { get; set; }
}