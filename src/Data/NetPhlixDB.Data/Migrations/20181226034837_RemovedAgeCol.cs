using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RemovedAgeCol : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Age",
                table: "AspNetUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 671, DateTimeKind.Utc).AddTicks(5650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 222, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 550, DateTimeKind.Utc).AddTicks(9664),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 125, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 677, DateTimeKind.Utc).AddTicks(3727),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 227, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 527, DateTimeKind.Utc).AddTicks(812),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 104, DateTimeKind.Utc).AddTicks(4195));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 222, DateTimeKind.Utc).AddTicks(268),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 671, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 125, DateTimeKind.Utc).AddTicks(4180),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 550, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 227, DateTimeKind.Utc).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 677, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.AddColumn<int>(
                name: "Age",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 104, DateTimeKind.Utc).AddTicks(4195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 527, DateTimeKind.Utc).AddTicks(812));
        }
    }
}
