using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Initial : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Key = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    passWord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    DateCreate = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CodeUnit = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Key);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
