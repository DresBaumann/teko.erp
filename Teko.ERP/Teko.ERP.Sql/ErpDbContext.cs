using Microsoft.EntityFrameworkCore;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql
{
	public class ErpDbContext : Microsoft.EntityFrameworkCore.DbContext
	{
		public DbSet<Article> Articles { get; set; } = null!;
		public DbSet<Location> Locations { get; set; } = null!;

		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			optionsBuilder.UseSqlServer(@"Connection string");
		}

	}
}