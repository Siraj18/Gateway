using Microsoft.EntityFrameworkCore.Migrations;

namespace Gateway.Data.Migrations
{
    public partial class AddClassProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "user_class",
                table: "users",
                type: "text",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "user_class",
                table: "users");
        }
    }
}
