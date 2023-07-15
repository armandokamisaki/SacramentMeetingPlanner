using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace SacramentMeetingPlanner.Migrations
{
    public partial class Speaker : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Member_MemberID",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "Date",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "MemberID",
                table: "Speaker",
                newName: "MemberId");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_MemberID",
                table: "Speaker",
                newName: "IX_Speaker_MemberId");

            migrationBuilder.AlterColumn<int>(
                name: "MemberId",
                table: "Speaker",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<string>(
                name: "MemberName",
                table: "Speaker",
                type: "nvarchar(max)",
                nullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Member_MemberId",
                table: "Speaker",
                column: "MemberId",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Speaker_Member_MemberId",
                table: "Speaker");

            migrationBuilder.DropColumn(
                name: "MemberName",
                table: "Speaker");

            migrationBuilder.RenameColumn(
                name: "MemberId",
                table: "Speaker",
                newName: "MemberID");

            migrationBuilder.RenameIndex(
                name: "IX_Speaker_MemberId",
                table: "Speaker",
                newName: "IX_Speaker_MemberID");

            migrationBuilder.AlterColumn<int>(
                name: "MemberID",
                table: "Speaker",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Speaker",
                type: "datetime2",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddForeignKey(
                name: "FK_Speaker_Member_MemberID",
                table: "Speaker",
                column: "MemberID",
                principalTable: "Member",
                principalColumn: "MemberId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
