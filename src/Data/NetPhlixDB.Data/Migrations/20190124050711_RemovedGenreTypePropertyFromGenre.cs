using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RemovedGenreTypePropertyFromGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "GenreType",
                table: "Genres");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 878, DateTimeKind.Utc).AddTicks(3719),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 914, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 825, DateTimeKind.Utc).AddTicks(1582),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 822, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 801, DateTimeKind.Utc).AddTicks(7216),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 779, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 881, DateTimeKind.Utc).AddTicks(3946),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 920, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 779, DateTimeKind.Utc).AddTicks(488),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 741, DateTimeKind.Utc).AddTicks(6144));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 914, DateTimeKind.Utc).AddTicks(3402),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 878, DateTimeKind.Utc).AddTicks(3719));

            migrationBuilder.AddColumn<string>(
                name: "GenreType",
                table: "Genres",
                nullable: false,
                defaultValue: "");

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 822, DateTimeKind.Utc).AddTicks(6640),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 825, DateTimeKind.Utc).AddTicks(1582));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 779, DateTimeKind.Utc).AddTicks(7493),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 801, DateTimeKind.Utc).AddTicks(7216));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 920, DateTimeKind.Utc).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 881, DateTimeKind.Utc).AddTicks(3946));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 741, DateTimeKind.Utc).AddTicks(6144),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 5, 7, 9, 779, DateTimeKind.Utc).AddTicks(488));
        }
    }
}
