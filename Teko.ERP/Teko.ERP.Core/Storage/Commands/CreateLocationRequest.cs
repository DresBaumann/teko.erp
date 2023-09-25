using System.ComponentModel.DataAnnotations;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Core.Storage.Commands;

public class CreateLocationRequest
{
	[Required]
	public int TenantId { get; set; }

	[Required]
	public string Name { get; set; }
	public string Description { get; set; }
	public string Address { get; set; }
	public List<ArticleStock> ArticleStocks { get; set; }
}