using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Changecolumn : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "AgentCode",
                table: "InvoiceDetails");

            migrationBuilder.DropColumn(
                name: "Expire",
                table: "InvoiceDetails");

            migrationBuilder.RenameColumn(
                name: "DateBuyin",
                table: "InvoiceDetails",
                newName: "DateExpire");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DateExpire",
                table: "InvoiceDetails",
                newName: "DateBuyin");

            migrationBuilder.AddColumn<string>(
                name: "AgentCode",
                table: "InvoiceDetails",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Expire",
                table: "InvoiceDetails",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }
    }
}
