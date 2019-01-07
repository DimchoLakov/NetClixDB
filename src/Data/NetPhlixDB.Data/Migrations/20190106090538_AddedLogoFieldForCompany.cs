using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedLogoFieldForCompany : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 603, DateTimeKind.Utc).AddTicks(9231),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 395, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 527, DateTimeKind.Utc).AddTicks(8462),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 323, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.AddColumn<string>(
                name: "Logo",
                table: "Companies",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 606, DateTimeKind.Utc).AddTicks(7591),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 398, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 511, DateTimeKind.Utc).AddTicks(7750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 308, DateTimeKind.Utc).AddTicks(6013));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Logo",
                table: "Companies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 395, DateTimeKind.Utc).AddTicks(8195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 603, DateTimeKind.Utc).AddTicks(9231));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 323, DateTimeKind.Utc).AddTicks(4750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 527, DateTimeKind.Utc).AddTicks(8462));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 398, DateTimeKind.Utc).AddTicks(5144),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 606, DateTimeKind.Utc).AddTicks(7591));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 308, DateTimeKind.Utc).AddTicks(6013),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 6, 9, 5, 37, 511, DateTimeKind.Utc).AddTicks(7750));
        }
    }
}
