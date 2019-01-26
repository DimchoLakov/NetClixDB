using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedNamePropertyForGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 914, DateTimeKind.Utc).AddTicks(3402),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 328, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.AddColumn<string>(
                name: "Name",
                table: "Genres",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 822, DateTimeKind.Utc).AddTicks(6640),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 263, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 779, DateTimeKind.Utc).AddTicks(7493),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 235, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 920, DateTimeKind.Utc).AddTicks(5708),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 332, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 741, DateTimeKind.Utc).AddTicks(6144),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 218, DateTimeKind.Utc).AddTicks(6984));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Name",
                table: "Genres");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 328, DateTimeKind.Utc).AddTicks(2907),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 914, DateTimeKind.Utc).AddTicks(3402));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 263, DateTimeKind.Utc).AddTicks(5333),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 822, DateTimeKind.Utc).AddTicks(6640));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 235, DateTimeKind.Utc).AddTicks(6109),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 779, DateTimeKind.Utc).AddTicks(7493));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 332, DateTimeKind.Utc).AddTicks(1500),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 920, DateTimeKind.Utc).AddTicks(5708));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 218, DateTimeKind.Utc).AddTicks(6984),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 58, 44, 741, DateTimeKind.Utc).AddTicks(6144));
        }
    }
}
