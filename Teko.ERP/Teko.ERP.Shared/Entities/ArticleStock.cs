namespace Teko.ERP.Shared.Entities;

public class ArticleStock
{
	public int Id { get; set; }

	public Article Article { get; set; }

	public Location Location { get; set; }
	public int Stock { get; set; }
}