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

	protected override void OnModelCreating(ModelBuilder modelBuilder)
	{
		// Tenant Relationships
		modelBuilder.Entity<Location>()
			.HasOne(l => l.Tenant)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Sale>()
			.HasOne(s => s.Tenant)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Order>()
			.HasOne(o => o.Tenant)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<Article>()
			.HasOne(a => a.Tenant)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		// Order Relationships
		modelBuilder.Entity<Order>()
			.HasOne(o => o.Creditor)
			.WithMany(c => c.Claims)
			.OnDelete(DeleteBehavior.Cascade);

		modelBuilder.Entity<Order>()
			.HasMany(o => o.ArticleOrders)
			.WithOne()
			.OnDelete(DeleteBehavior.Cascade);

		// Debitor Relationships
		modelBuilder.Entity<Sale>()
			.HasOne(s => s.Debitor)
			.WithMany(d => d.Bills)
			.OnDelete(DeleteBehavior.Cascade);

		// Article Relationships
		modelBuilder.Entity<ArticleOrder>()
			.HasOne(ao => ao.Article)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ArticleOrder>()
			.HasOne(aOrder => aOrder.Article)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ArticleSale>()
			.HasOne(aSale => aSale.Article)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		modelBuilder.Entity<ArticleStock>()
			.HasOne(aStock => aStock.Article)
			.WithMany()
			.OnDelete(DeleteBehavior.Restrict);

		// Sale Relationships
		modelBuilder.Entity<Sale>()
			.HasMany(s => s.ArticleSales)
			.WithOne()
			.OnDelete(DeleteBehavior.Cascade);
	}

	protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
	{
		optionsBuilder.UseSqlServer(@"
  Server=127.0.0.1,1433;
  Database=Master;
  User Id=SA;
  Password=veryStrongTekoPassword!;
TrustServerCertificate=True;");
	}
}