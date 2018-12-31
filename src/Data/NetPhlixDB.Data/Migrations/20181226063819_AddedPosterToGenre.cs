using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedPosterToGenre : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 54, DateTimeKind.Utc).AddTicks(660),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 671, DateTimeKind.Utc).AddTicks(5650));

            migrationBuilder.AddColumn<string>(
                name: "Poster",
                table: "Genres",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 981, DateTimeKind.Utc).AddTicks(6789),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 550, DateTimeKind.Utc).AddTicks(9664));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 57, DateTimeKind.Utc).AddTicks(2747),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 677, DateTimeKind.Utc).AddTicks(3727));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 961, DateTimeKind.Utc).AddTicks(3995),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 527, DateTimeKind.Utc).AddTicks(812));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Poster",
                table: "Genres");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 671, DateTimeKind.Utc).AddTicks(5650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 54, DateTimeKind.Utc).AddTicks(660));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 550, DateTimeKind.Utc).AddTicks(9664),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 981, DateTimeKind.Utc).AddTicks(6789));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 677, DateTimeKind.Utc).AddTicks(3727),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 18, 57, DateTimeKind.Utc).AddTicks(2747));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 3, 48, 36, 527, DateTimeKind.Utc).AddTicks(812),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 38, 17, 961, DateTimeKind.Utc).AddTicks(3995));
        }
    }
}
