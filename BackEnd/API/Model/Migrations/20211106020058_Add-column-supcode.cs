using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Addcolumnsupcode : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupCode",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "SupCode",
                table: "Invoices",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "SupCode",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "SupCode",
                table: "InvoiceDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
