using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedPosterPropertyToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 570, DateTimeKind.Utc).AddTicks(8679),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 54, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 498, DateTimeKind.Utc).AddTicks(784),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 981, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 574, DateTimeKind.Utc).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 57, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 483, DateTimeKind.Utc).AddTicks(9643),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 961, DateTimeKind.Utc).AddTicks(3995));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 54, DateTimeKind.Utc).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 570, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 981, DateTimeKind.Utc).AddTicks(6789),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 498, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 57, DateTimeKind.Utc).AddTicks(2747),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 574, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 961, DateTimeKind.Utc).AddTicks(3995),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 483, DateTimeKind.Utc).AddTicks(9643));
        }
    }
}
