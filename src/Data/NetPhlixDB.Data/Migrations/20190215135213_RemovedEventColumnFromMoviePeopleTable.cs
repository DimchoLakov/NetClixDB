using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RemovedEventColumnFromMoviePeopleTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
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
                defaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 660, DateTimeKind.Utc).AddTicks(2640),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 808, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 592, DateTimeKind.Utc).AddTicks(4089),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 743, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 590, DateTimeKind.Utc).AddTicks(6817),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 708, DateTimeKind.Utc).AddTicks(3290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 665, DateTimeKind.Utc).AddTicks(5799),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 813, DateTimeKind.Utc).AddTicks(3718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 571, DateTimeKind.Utc).AddTicks(8554),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 685, DateTimeKind.Utc).AddTicks(5787));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 808, DateTimeKind.Utc).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 660, DateTimeKind.Utc).AddTicks(2640));

            migrationBuilder.AddColumn<string>(
                name: "EventId",
                table: "MoviePeople",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 743, DateTimeKind.Utc).AddTicks(1387),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 592, DateTimeKind.Utc).AddTicks(4089));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 708, DateTimeKind.Utc).AddTicks(3290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 590, DateTimeKind.Utc).AddTicks(6817));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 813, DateTimeKind.Utc).AddTicks(3718),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 665, DateTimeKind.Utc).AddTicks(5799));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 685, DateTimeKind.Utc).AddTicks(5787),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 15, 13, 52, 12, 571, DateTimeKind.Utc).AddTicks(8554));

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
    }
}
