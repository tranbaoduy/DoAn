using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Createtableuser3 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    userName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    passWord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true),
                    fullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    AgentCode = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userName);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
