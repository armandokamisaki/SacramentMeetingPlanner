using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class PlannerFix : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Hymn1ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Hymn2ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Hymn3ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Hymn4ID",
                table: "Planner");

            migrationBuilder.AddColumn<string>(
                name: "ClosingHymn",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "DismissalSong",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "OpeningHymn",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "SacramentHymn",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "ClosingHymn",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "DismissalSong",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "OpeningHymn",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "SacramentHymn",
                table: "Planner");

            migrationBuilder.AddColumn<int>(
                name: "Hymn1ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hymn2ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hymn3ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Hymn4ID",
                table: "Planner",
                type: "int",
                nullable: true);
        }
    }
}
