namespace Teko.ERP.Shared.Entities;

public class Creditor : Account
{
	public string Iban { get; set; }

	private List<Order> Claims { get; set; }
}