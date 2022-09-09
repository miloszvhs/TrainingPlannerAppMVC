using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlannerAppMVC.Infrastructure.Migrations
{
    public partial class DeletedSetsFromSet : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Sets",
                table: "DayExerciseSets");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Sets",
                table: "DayExerciseSets",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
