using System.ComponentModel.DataAnnotations;

namespace Teko.ERP.Core.Finance.Commands;

public class CreateAccountRequest
{
	[Required]
	public int TenantId { get; set; }

	[Required]
	public string? FirstName { get; set; }

	[Required]
	public string? LastName { get; set; }

	public string? PhoneNumber { get; set; }

	public string? Street { get; set; }

	public int Plz { get; set; }

	public string? City { get; set; }
}