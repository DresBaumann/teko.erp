using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teko.ERP.Sql.Migrations
{
    /// <inheritdoc />
    public partial class addfunctionality : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Locations_LocationId",
                table: "Articles");

            migrationBuilder.DropColumn(
                name: "Amount",
                table: "Articles");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "Articles",
                newName: "TenantId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_LocationId",
                table: "Articles",
                newName: "IX_Articles_TenantId");

            migrationBuilder.AddColumn<int>(
                name: "TenantId",
                table: "Locations",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "ArticleStocks",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    Stock = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleStocks", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleStocks_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleStocks_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tenants",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    FinanceModuleActive = table.Column<bool>(type: "bit", nullable: false),
                    OrderModuleActive = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Tenants", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Creditors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Iban = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plz = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Creditors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Creditors_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Debitors",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Street = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Plz = table.Column<int>(type: "int", nullable: false),
                    City = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Debitors", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Debitors_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Orders",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "int", nullable: false),
                    CreditorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    ClaimState = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Orders", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Orders_Creditors_CreditorId",
                        column: x => x.CreditorId,
                        principalTable: "Creditors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Orders_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Sales",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DebitorId = table.Column<int>(type: "int", nullable: false),
                    ReferenceNumber = table.Column<int>(type: "int", nullable: false),
                    ClaimState = table.Column<int>(type: "int", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    TenantId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Sales", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Sales_Debitors_DebitorId",
                        column: x => x.DebitorId,
                        principalTable: "Debitors",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Sales_Tenants_TenantId",
                        column: x => x.TenantId,
                        principalTable: "Tenants",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ArticleOrder",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    OrderId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleOrder", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleOrder_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleOrder_Orders_OrderId",
                        column: x => x.OrderId,
                        principalTable: "Orders",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateTable(
                name: "ArticleSale",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ArticleId = table.Column<int>(type: "int", nullable: false),
                    Quantity = table.Column<int>(type: "int", nullable: false),
                    SaleId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ArticleSale", x => x.Id);
                    table.ForeignKey(
                        name: "FK_ArticleSale_Articles_ArticleId",
                        column: x => x.ArticleId,
                        principalTable: "Articles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_ArticleSale_Sales_SaleId",
                        column: x => x.SaleId,
                        principalTable: "Sales",
                        principalColumn: "Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Locations_TenantId",
                table: "Locations",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOrder_ArticleId",
                table: "ArticleOrder",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleOrder_OrderId",
                table: "ArticleOrder",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSale_ArticleId",
                table: "ArticleSale",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleSale_SaleId",
                table: "ArticleSale",
                column: "SaleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStocks_ArticleId",
                table: "ArticleStocks",
                column: "ArticleId");

            migrationBuilder.CreateIndex(
                name: "IX_ArticleStocks_LocationId",
                table: "ArticleStocks",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_Creditors_TenantId",
                table: "Creditors",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Debitors_TenantId",
                table: "Debitors",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_CreditorId",
                table: "Orders",
                column: "CreditorId");

            migrationBuilder.CreateIndex(
                name: "IX_Orders_TenantId",
                table: "Orders",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_DebitorId",
                table: "Sales",
                column: "DebitorId");

            migrationBuilder.CreateIndex(
                name: "IX_Sales_TenantId",
                table: "Sales",
                column: "TenantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Tenants_TenantId",
                table: "Articles",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Locations_Tenants_TenantId",
                table: "Locations",
                column: "TenantId",
                principalTable: "Tenants",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Articles_Tenants_TenantId",
                table: "Articles");

            migrationBuilder.DropForeignKey(
                name: "FK_Locations_Tenants_TenantId",
                table: "Locations");

            migrationBuilder.DropTable(
                name: "ArticleOrder");

            migrationBuilder.DropTable(
                name: "ArticleSale");

            migrationBuilder.DropTable(
                name: "ArticleStocks");

            migrationBuilder.DropTable(
                name: "Orders");

            migrationBuilder.DropTable(
                name: "Sales");

            migrationBuilder.DropTable(
                name: "Creditors");

            migrationBuilder.DropTable(
                name: "Debitors");

            migrationBuilder.DropTable(
                name: "Tenants");

            migrationBuilder.DropIndex(
                name: "IX_Locations_TenantId",
                table: "Locations");

            migrationBuilder.DropColumn(
                name: "TenantId",
                table: "Locations");

            migrationBuilder.RenameColumn(
                name: "TenantId",
                table: "Articles",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_Articles_TenantId",
                table: "Articles",
                newName: "IX_Articles_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "Amount",
                table: "Articles",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Articles_Locations_LocationId",
                table: "Articles",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
