using Teko.ERP.Core.Finance.Commands;
using Teko.ERP.Core.Finance.Queries;
using Teko.ERP.Core.Orders.Commands;
using Teko.ERP.Core.Orders.Queries;
using Teko.ERP.Core.Storage.Commands;
using Teko.ERP.Core.Storage.Queries;
using Teko.ERP.Core.Tenant.Commands;
using Teko.ERP.Core.Tenant.Queries;
using Teko.ERP.Sql;
using Teko.ERP.Sql.Repositories;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Register DB

builder.Services.AddSingleton<ArticleRepository>();
builder.Services.AddSingleton<AccountRepository>();
builder.Services.AddSingleton<LocationRepository>();
builder.Services.AddSingleton<TenantRepository>();
builder.Services.AddSingleton<ErpDbContext>();

// Register Commands
builder.Services.AddTransient<CreateCreditorCommand>();
builder.Services.AddTransient<CreateDebitorCommand>();
builder.Services.AddTransient<CreateSaleCommand>();
builder.Services.AddTransient<CreateOrderCommand>();
builder.Services.AddTransient<CreateArticleCommand>();
builder.Services.AddTransient<CreateLocationCommand>();
builder.Services.AddTransient<SetArticleStockCommand>();
builder.Services.AddTransient<CreateTenantCommand>();


// Register Queries
builder.Services.AddTransient<GetArticleTurnoverQuery>();
builder.Services.AddTransient<GetCreditorsQuery>();
builder.Services.AddTransient<GetDebitorsQuery>();
builder.Services.AddTransient<GetDueDebitorsQuery>();
builder.Services.AddTransient<CheckLocationExistsQuery>();
builder.Services.AddTransient<GetAbcListQuery>();
builder.Services.AddTransient<GetArticlesQuery>();
builder.Services.AddTransient<GetArticleStocksQuery>();
builder.Services.AddTransient<GetLocationsQuery>();
builder.Services.AddTransient<CheckTenantExistsQuery>();
builder.Services.AddTransient<IsOrderModuleActivatedQuery>();
builder.Services.AddTransient<IsStorageModuleActivatedQuery>();
builder.Services.AddTransient<GetTenantsQuery>();
builder.Services.AddTransient<GetOrdersQuery>();


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
	app.UseSwagger();
	app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
