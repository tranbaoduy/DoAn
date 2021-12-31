using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Add2tableinvoice : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InvoiceDetails",
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
                    Expire = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateBuyin = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DateMade = table.Column<DateTime>(type: "datetime2", nullable: false),
                    SupCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    AgentCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Total = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    NameCus = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_InvoiceDetails", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "Invoices",
                columns: table => new
                {
                    InvoiceCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    TypeInvoice = table.Column<int>(type: "int", nullable: false),
                    TotalInvoice = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Status = table.Column<int>(type: "int", nullable: false),
                    Paid = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserCreate = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    DateCreate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    AgentCode = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Invoices", x => x.InvoiceCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InvoiceDetails");

            migrationBuilder.DropTable(
                name: "Invoices");
        }
    }
}
