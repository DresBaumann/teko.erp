using System.ComponentModel.DataAnnotations;

namespace Teko.ERP.Core.Tenant.Commands;

public class CreateTenantRequest
{
	[Required]
	public string Name { get; set; }
	public bool FinanceModuleActive { get; set; } = false;
	public bool StorageModuleActive { get; set; } = false;
	public bool OrderModuleActive { get; set; } = false;
}