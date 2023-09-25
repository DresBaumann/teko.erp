namespace Teko.ERP.Shared.Entities;

public class Account
{
	public int Id { get; set; }
	public Tenant Tenant { get; set; }
	public string FirstName { get; set; }
	public string LastName { get; set; }

	public string PhoneNumber { get; set; }

	public string Street { get; set; }

	public int Plz { get; set; }

	public string City { get; set; }

	public string FullName => $"{FirstName} {LastName}";
}