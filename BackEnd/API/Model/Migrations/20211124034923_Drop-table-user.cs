using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Droptableuser : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CodeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    passWord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    userName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Key);
                });
        }
    }
}
