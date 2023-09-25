namespace Teko.ERP.Shared.Entities;

public class Debitor : Account
{
	public List<Sale> Bills { get; set; }
}