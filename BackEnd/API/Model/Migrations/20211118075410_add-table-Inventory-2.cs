using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addtableInventory2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Inventorys",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    InvoiceRefid = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    CodeMedicine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameMedice = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Count = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Price = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    SeriNumber = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateExpire = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateBuy = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgentCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Inventorys", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Inventorys");
        }
    }
}
