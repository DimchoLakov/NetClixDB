using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class EventNavigationProperty : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePeople_Events_Id",
                table: "MoviePeople");

            migrationBuilder.DropIndex(
                name: "IX_MoviePeople_Id",
                table: "MoviePeople");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 865, DateTimeKind.Utc).AddTicks(4329),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 210, DateTimeKind.Utc).AddTicks(7778));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "MoviePeople",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "MoviePeople",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 776, DateTimeKind.Utc).AddTicks(8885),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 130, DateTimeKind.Utc).AddTicks(9057));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 868, DateTimeKind.Utc).AddTicks(6215),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 217, DateTimeKind.Utc).AddTicks(7278));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 760, DateTimeKind.Utc).AddTicks(481),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 114, DateTimeKind.Utc).AddTicks(9675));

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_EventId",
                table: "MoviePeople",
                column: "EventId");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePeople_Events_EventId",
                table: "MoviePeople",
                column: "EventId",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_MoviePeople_Events_EventId",
                table: "MoviePeople");

            migrationBuilder.DropIndex(
                name: "IX_MoviePeople_EventId",
                table: "MoviePeople");

            migrationBuilder.DropColumn(
                name: "EventId",
                table: "MoviePeople");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 210, DateTimeKind.Utc).AddTicks(7778),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 865, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.AlterColumn<string>(
                name: "Id",
                table: "MoviePeople",
                nullable: true,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 130, DateTimeKind.Utc).AddTicks(9057),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 776, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 217, DateTimeKind.Utc).AddTicks(7278),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 868, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 43, 12, 114, DateTimeKind.Utc).AddTicks(9675),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 760, DateTimeKind.Utc).AddTicks(481));

            migrationBuilder.CreateIndex(
                name: "IX_MoviePeople_Id",
                table: "MoviePeople",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_MoviePeople_Events_Id",
                table: "MoviePeople",
                column: "Id",
                principalTable: "Events",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
