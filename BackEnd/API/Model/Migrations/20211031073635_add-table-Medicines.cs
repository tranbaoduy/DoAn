using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class addtableMedicines : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Medicines",
                columns: table => new
                {
                    CodeMedicine = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NameMedice = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DosageForm = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    ExChange = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    UnitLast = table.Column<string>(type: "nvarchar(20)", maxLength: 20, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Medicines", x => x.CodeMedicine);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Medicines");
        }
    }
}
