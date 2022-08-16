using Microsoft.EntityFrameworkCore.Migrations;

namespace Gateway.Data.Migrations
{
    public partial class AddStatisticsCourseRelation : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "counter",
                table: "levels",
                type: "integer",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateTable(
                name: "course_db_model_statistic_db_model",
                columns: table => new
                {
                    courses_id = table.Column<int>(type: "integer", nullable: false),
                    statistics_id = table.Column<int>(type: "integer", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("pk_course_db_model_statistic_db_model", x => new { x.courses_id, x.statistics_id });
                    table.ForeignKey(
                        name: "fk_course_db_model_statistic_db_model_courses_courses_id",
                        column: x => x.courses_id,
                        principalTable: "courses",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "fk_course_db_model_statistic_db_model_statistics_statistics_id",
                        column: x => x.statistics_id,
                        principalTable: "statistics",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "ix_course_db_model_statistic_db_model_statistics_id",
                table: "course_db_model_statistic_db_model",
                column: "statistics_id");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "course_db_model_statistic_db_model");

            migrationBuilder.DropColumn(
                name: "counter",
                table: "levels");
        }
    }
}
