using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class UserBirthDateCanBeNull : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 222, DateTimeKind.Utc).AddTicks(268),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 799, DateTimeKind.Utc).AddTicks(1065));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 125, DateTimeKind.Utc).AddTicks(4180),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 682, DateTimeKind.Utc).AddTicks(5935));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 227, DateTimeKind.Utc).AddTicks(7386),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 806, DateTimeKind.Utc).AddTicks(1594));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: true,
                oldClrType: typeof(DateTime));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 104, DateTimeKind.Utc).AddTicks(4195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 655, DateTimeKind.Utc).AddTicks(2243));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 799, DateTimeKind.Utc).AddTicks(1065),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 222, DateTimeKind.Utc).AddTicks(268));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 682, DateTimeKind.Utc).AddTicks(5935),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 125, DateTimeKind.Utc).AddTicks(4180));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 806, DateTimeKind.Utc).AddTicks(1594),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 227, DateTimeKind.Utc).AddTicks(7386));

            migrationBuilder.AlterColumn<DateTime>(
                name: "BirthDate",
                table: "AspNetUsers",
                nullable: false,
                oldClrType: typeof(DateTime),
                oldNullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 25, 5, 55, 1, 655, DateTimeKind.Utc).AddTicks(2243),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 47, 34, 104, DateTimeKind.Utc).AddTicks(4195));
        }
    }
}
