using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class AddcolumstatusdeletecolumInvoiceRefid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "InvoiceRefid",
                table: "Inventorys");

            migrationBuilder.AddColumn<int>(
                name: "status",
                table: "Inventorys",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "Inventorys");

            migrationBuilder.AddColumn<string>(
                name: "InvoiceRefid",
                table: "Inventorys",
                type: "nvarchar(100)",
                maxLength: 100,
                nullable: true);
        }
    }
}
