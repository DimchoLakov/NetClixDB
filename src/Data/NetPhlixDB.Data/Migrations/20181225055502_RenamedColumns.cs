using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RenamedColumns : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "ReviewContent",
                table: "Reviews",
                newName: "Content");

            migrationBuilder.RenameColumn(
                name: "MovieRating",
                table: "Movies",
                newName: "Rating");

            migrationBuilder.RenameColumn(
                name: "CompanyName",
                table: "Companies",
                newName: "Name");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 799, DateTimeKind.Utc).AddTicks(1065),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 865, DateTimeKind.Utc).AddTicks(4329));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 682, DateTimeKind.Utc).AddTicks(5935),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 776, DateTimeKind.Utc).AddTicks(8885));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 806, DateTimeKind.Utc).AddTicks(1594),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 868, DateTimeKind.Utc).AddTicks(6215));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 655, DateTimeKind.Utc).AddTicks(2243),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 760, DateTimeKind.Utc).AddTicks(481));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Content",
                table: "Reviews",
                newName: "ReviewContent");

            migrationBuilder.RenameColumn(
                name: "Rating",
                table: "Movies",
                newName: "MovieRating");

            migrationBuilder.RenameColumn(
                name: "Name",
                table: "Companies",
                newName: "CompanyName");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 865, DateTimeKind.Utc).AddTicks(4329),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 799, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 776, DateTimeKind.Utc).AddTicks(8885),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 682, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 868, DateTimeKind.Utc).AddTicks(6215),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 806, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 50, 30, 760, DateTimeKind.Utc).AddTicks(481),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 655, DateTimeKind.Utc).AddTicks(2243));
        }
    }
}
