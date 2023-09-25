using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Teko.ERP.Sql.Migrations
{
    /// <inheritdoc />
    public partial class tenantFix : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "StorageModuleActive",
                table: "Tenants",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "StorageModuleActive",
                table: "Tenants");
        }
    }
}
