using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Rating : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Planner_Speaker_SpeakerID",
                table: "Planner");

            migrationBuilder.DropIndex(
                name: "IX_Planner_SpeakerID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Speaker1ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Speaker2ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Speaker3ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "Speaker4ID",
                table: "Planner");

            migrationBuilder.DropColumn(
                name: "SpeakerID",
                table: "Planner");

            migrationBuilder.RenameColumn(
                name: "PlannerId",
                table: "Planner",
                newName: "PlannerID");

            migrationBuilder.AddColumn<int>(
                name: "PlannerID",
                table: "Speaker",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_PlannerID",
                table: "Speaker",
                column: "PlannerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Planner_PlannerID",
                table: "Speaker",
                column: "PlannerID",
                principalTable: "Planner",
                principalColumn: "PlannerID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Planner_PlannerID",
                table: "Speaker");

            migrationBuilder.DropIndex(
                name: "IX_Speaker_PlannerID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "PlannerID",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "PlannerID",
                table: "Planner",
                newName: "PlannerId");

            migrationBuilder.AddColumn<int>(
                name: "Speaker1ID",
                table: "Planner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speaker2ID",
                table: "Planner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speaker3ID",
                table: "Planner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "Speaker4ID",
                table: "Planner",
                type: "int",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "SpeakerID",
                table: "Planner",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Planner_SpeakerID",
                table: "Planner",
                column: "SpeakerID");

            migrationBuilder.AddForeignKey(
                name: "FK_Planner_Speaker_SpeakerID",
                table: "Planner",
                column: "SpeakerID",
                principalTable: "Speaker",
                principalColumn: "SpeakerID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
