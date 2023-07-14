using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Member : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Member1ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Member2ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Member3ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Member4ID",
                table: "Planner");

            migrationBuilder.AddColumn<string>(
                name: "Benediction",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Conducting",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Invocation",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "President",
                table: "Planner",
                type: "nvarchar(max)",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Benediction",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Conducting",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Invocation",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "President",
                table: "Planner");

            migrationBuilder.AddColumn<int>(
                name: "Member1ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member2ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member3ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Member4ID",
                table: "Planner",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
