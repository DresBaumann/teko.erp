using Teko.ERP.Core.Storage.Commands;
using Teko.ERP.Core.Storage.Queries;
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
builder.Services.AddSingleton<ErpDbContext>();

// Register Commands
builder.Services.AddTransient<CreateArticleCommand>();

// Register Queries
builder.Services.AddTransient<AllArticlesQuery>();


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
