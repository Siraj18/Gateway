using Microsoft.EntityFrameworkCore.Migrations;

namespace Gateway.Data.Migrations
{
    public partial class AddTypeAndAnswerColumnsToLevel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "answer",
                table: "levels",
                type: "text",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "type",
                table: "levels",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "answer",
                table: "levels");

            migrationBuilder.DropColumn(
                name: "type",
                table: "levels");
        }
    }
}
