using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class add3tablefuncion : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "functions",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeFunction = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    nameFunction = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    url = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_functions", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "groupFunctions",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    groups = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_groupFunctions", x => x.Key);
                });

            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    codeFunction = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    userName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    Insert = table.Column<int>(type: "int", nullable: false),
                    Edit = table.Column<int>(type: "int", nullable: false),
                    Delete = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "functions");

            migrationBuilder.DropTable(
                name: "groupFunctions");

            migrationBuilder.DropTable(
                name: "Permissions");
        }
    }
}
