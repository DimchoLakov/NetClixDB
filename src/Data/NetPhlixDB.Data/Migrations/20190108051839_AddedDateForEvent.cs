using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedDateForEvent : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 948, DateTimeKind.Utc).AddTicks(5210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 603, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.AddColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 902, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 875, DateTimeKind.Utc).AddTicks(1480),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 527, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 952, DateTimeKind.Utc).AddTicks(5707),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 606, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 861, DateTimeKind.Utc).AddTicks(6043),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 511, DateTimeKind.Utc).AddTicks(7750));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Date",
                table: "Events");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 603, DateTimeKind.Utc).AddTicks(9231),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 948, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 527, DateTimeKind.Utc).AddTicks(8462),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 875, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 606, DateTimeKind.Utc).AddTicks(7591),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 952, DateTimeKind.Utc).AddTicks(5707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 511, DateTimeKind.Utc).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 861, DateTimeKind.Utc).AddTicks(6043));
        }
    }
}
