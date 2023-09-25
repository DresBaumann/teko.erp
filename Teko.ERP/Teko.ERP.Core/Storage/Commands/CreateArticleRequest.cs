namespace Teko.ERP.Core.Storage.Commands;

public class CreateArticleRequest
{
	public string Name { get; set; }
	public int Price { get; set; }
	public string Description { get; set; }
	public int TenantId { get; set; }
}