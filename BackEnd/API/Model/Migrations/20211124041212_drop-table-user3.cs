using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class droptableuser3 : Migration
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
                    userName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    AgentCode = table.Column<int>(type: "int", nullable: false),
                    fullName = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    passWord = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: true),
                    role = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.userName);
                });
        }
    }
}
