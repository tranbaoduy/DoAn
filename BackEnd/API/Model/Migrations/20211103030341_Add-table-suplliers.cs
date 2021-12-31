using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Addtablesuplliers : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Suppliers",
                columns: table => new
                {
                    SupCode = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    SupName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SupAddress = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    SupPhone = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Paid = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    Dept = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Suppliers", x => x.SupCode);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Suppliers");
        }
    }
}
