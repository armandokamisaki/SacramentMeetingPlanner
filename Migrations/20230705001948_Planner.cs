using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Planner : Migration
    {
        public int PlannerID { get; internal set; }
        public object Member1ID { get; internal set; }
        public object Hymn1ID { get; internal set; }
        public object President { get; internal set; }

        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Hymn",
                columns: table => new
                {
                    HymnID = table.Column<int>(type: "int", nullable: false),
                    HymnName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hymn", x => x.HymnID);
                });

            migrationBuilder.CreateTable(
                name: "Member",
                columns: table => new
                {
                    MemberId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FirstName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Member", x => x.MemberId);
                });

            migrationBuilder.CreateTable(
                name: "Speaker",
                columns: table => new
                {
                    SpeakerID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    MemberID = table.Column<int>(type: "int", nullable: false),
                    Topic = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Speaker", x => x.SpeakerID);
                    table.ForeignKey(
                        name: "FK_Speaker_Member_MemberID",
                        column: x => x.MemberID,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Planner",
                columns: table => new
                {
                    PlannerId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Member1ID = table.Column<int>(type: "int", nullable: false),
                    Member2ID = table.Column<int>(type: "int", nullable: false),
                    Hymn1ID = table.Column<int>(type: "int", nullable: false),
                    Member3ID = table.Column<int>(type: "int", nullable: false),
                    Hymn2ID = table.Column<int>(type: "int", nullable: false),
                    Speaker1ID = table.Column<int>(type: "int", nullable: true),
                    Speaker2ID = table.Column<int>(type: "int", nullable: true),
                    Speaker3ID = table.Column<int>(type: "int", nullable: true),
                    SpecialHymn = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Speaker4ID = table.Column<int>(type: "int", nullable: true),
                    Hymn3ID = table.Column<int>(type: "int", nullable: false),
                    Member4ID = table.Column<int>(type: "int", nullable: false),
                    Hymn4ID = table.Column<int>(type: "int", nullable: true),
                    MemberId = table.Column<int>(type: "int", nullable: true),
                    HymnID = table.Column<int>(type: "int", nullable: true),
                    SpeakerID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Planner", x => x.PlannerId);
                    table.ForeignKey(
                        name: "FK_Planner_Hymn_HymnID",
                        column: x => x.HymnID,
                        principalTable: "Hymn",
                        principalColumn: "HymnID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planner_Member_MemberId",
                        column: x => x.MemberId,
                        principalTable: "Member",
                        principalColumn: "MemberId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Planner_Speaker_SpeakerID",
                        column: x => x.SpeakerID,
                        principalTable: "Speaker",
                        principalColumn: "SpeakerID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Planner_HymnID",
                table: "Planner",
                column: "HymnID");

            migrationBuilder.CreateIndex(
                name: "IX_Planner_MemberId",
                table: "Planner",
                column: "MemberId");

            migrationBuilder.CreateIndex(
                name: "IX_Planner_SpeakerID",
                table: "Planner",
                column: "SpeakerID");

            migrationBuilder.CreateIndex(
                name: "IX_Speaker_MemberID",
                table: "Speaker",
                column: "MemberID");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Planner");

            migrationBuilder.DropTable(
                name: "Hymn");

            migrationBuilder.DropTable(
                name: "Speaker");

            migrationBuilder.DropTable(
                name: "Member");
        }
    }
}
