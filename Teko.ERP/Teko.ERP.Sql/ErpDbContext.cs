using Microsoft.EntityFrameworkCore;
using Teko.ERP.Shared.Entities;

namespace Teko.ERP.Sql;

public class ErpDbContext : DbContext
{
	public DbSet<Article> Articles { get; set; } = null!;
	public DbSet<Location> Locations { get; set; } = null!;
	public DbSet<Creditor> Creditors { get; set; } = null!;
	public DbSet<Debitor> Debitors { get; set; } = null!;
	public DbSet<Tenant> Tenants { get; set; } = null!;
	public DbSet<Order> Orders { get; set; } = null!;
	public DbSet<Sale> Sales { get; set; } = null!;
	public DbSet<ArticleStock?> ArticleStocks { get; set; } = null!;
	public DbSet<ArticleOrder> ArticleOrders { get; set; } = null!;

	public DbSet<ArticleOrder> ArticleSales { get; set; } = null!;

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"
  Server=127.0.0.1,1433;
  Database=Master;
  User Id=SA;
  Password=veryStrongTekoPassword!");
	}
}