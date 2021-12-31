using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Changecolumn2tableinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCus",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "InvoiceDetails");

            migrationBuilder.AddColumn<string>(
                name: "NameCus",
                table: "Invoices",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "Invoices",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "NameCus",
                table: "Invoices");

            migrationBuilder.DropColumn(
                name: "PhoneNumber",
                table: "Invoices");

            migrationBuilder.AddColumn<string>(
                name: "NameCus",
                table: "InvoiceDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "PhoneNumber",
                table: "InvoiceDetails",
                type: "nvarchar(500)",
                maxLength: 500,
                nullable: true);
        }
    }
}
