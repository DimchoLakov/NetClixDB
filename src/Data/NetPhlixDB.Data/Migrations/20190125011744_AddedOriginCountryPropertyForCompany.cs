using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedOriginCountryPropertyForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 45, DateTimeKind.Utc).AddTicks(4301),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 878, DateTimeKind.Utc).AddTicks(3719));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(string));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 955, DateTimeKind.Utc).AddTicks(8086),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 825, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 911, DateTimeKind.Utc).AddTicks(1737),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 801, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.AddColumn<string>(
                name: "OriginCountry",
                table: "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 52, DateTimeKind.Utc).AddTicks(933),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 881, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 878, DateTimeKind.Utc).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 779, DateTimeKind.Utc).AddTicks(488));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "OriginCountry",
                table: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 878, DateTimeKind.Utc).AddTicks(3719),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 45, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 825, DateTimeKind.Utc).AddTicks(1582),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 955, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 801, DateTimeKind.Utc).AddTicks(7216),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 911, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 881, DateTimeKind.Utc).AddTicks(3946),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 52, DateTimeKind.Utc).AddTicks(933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 779, DateTimeKind.Utc).AddTicks(488),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 878, DateTimeKind.Utc).AddTicks(1671));
        }
    }
}
