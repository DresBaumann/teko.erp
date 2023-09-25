namespace Teko.ERP.Shared.Entities;

public class Creditor : Account
{
	public string Iban { get; set; }

	public List<Order> Claims { get; set; }
}