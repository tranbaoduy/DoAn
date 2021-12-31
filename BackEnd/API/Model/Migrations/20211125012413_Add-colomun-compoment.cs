using Microsoft.EntityFrameworkCore.Migrations;

namespace Model.Migrations
{
    public partial class Addcolomuncompoment : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "component",
                table: "functions",
                type: "nvarchar(200)",
                maxLength: 200,
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "component",
                table: "functions");
        }
    }
}
