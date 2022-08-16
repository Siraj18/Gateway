using Microsoft.EntityFrameworkCore.Migrations;

namespace Gateway.Data.Migrations
{
    public partial class AddIsLastProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "is_last",
                table: "levels",
                type: "boolean",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "is_last",
                table: "levels");
        }
    }
}
