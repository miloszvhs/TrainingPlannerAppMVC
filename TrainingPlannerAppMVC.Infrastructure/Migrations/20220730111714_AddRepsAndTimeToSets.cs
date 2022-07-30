using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace TrainingPlannerAppMVC.Infrastructure.Migrations
{
    public partial class AddRepsAndTimeToSets : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakTimeInSeconds",
                table: "ExerciseDetails");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "ExerciseDetails");

            migrationBuilder.AddColumn<int>(
                name: "BreakTimeInSeconds",
                table: "ExerciseSet",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "ExerciseSet",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "BreakTimeInSeconds",
                table: "ExerciseSet");

            migrationBuilder.DropColumn(
                name: "Reps",
                table: "ExerciseSet");

            migrationBuilder.AddColumn<int>(
                name: "BreakTimeInSeconds",
                table: "ExerciseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Reps",
                table: "ExerciseDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
