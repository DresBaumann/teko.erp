using System.ComponentModel.DataAnnotations;

namespace Teko.ERP.Shared.Entities;

public class Article
{
	public int Id { get; set; }

	[MaxLength(50)] public string Name { get; set; }

	public string Description { get; set; }

	public int Price { get; set; }

	public Location Location { get; set; }

	public int Amount { get; set; }
}