namespace Teko.ERP.Shared.Entities;

public class Tenant
{
	public string Name { get; set; }
	public int Id { get; set; }
	public bool FinanceModuleActive { get; set; }
	public bool StorageModuleActive { get;}
	public bool OrderModuleActive { get; set; }
}