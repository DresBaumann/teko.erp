namespace Teko.ERP.Shared.Entities;

public class Location
{
	public Tenant Tenant { get; set; }
	public int Id { get; set; }
	public string Name { get; set; }
	public string Description { get; set; }
	public string Address { get; set; }
	public List<ArticleStock> ArticleStocks { get; set; }
}