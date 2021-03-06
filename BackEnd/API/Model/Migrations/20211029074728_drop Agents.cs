using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class dropAgents : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Agents");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Agents",
                columns: table => new
                {
                    AgentCode = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    AddressAgent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    NameAgent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    PhoneAgent = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Agents", x => x.AgentCode);
                });
        }
    }
}
