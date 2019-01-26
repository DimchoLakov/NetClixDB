using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RemovedRatingPropertyForMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Rating",
                table: "Movies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 375, DateTimeKind.Utc).AddTicks(6710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 948, DateTimeKind.Utc).AddTicks(5210));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 323, DateTimeKind.Utc).AddTicks(6169),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 902, DateTimeKind.Utc).AddTicks(7704));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 299, DateTimeKind.Utc).AddTicks(9571),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 875, DateTimeKind.Utc).AddTicks(1480));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 378, DateTimeKind.Utc).AddTicks(3326),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 952, DateTimeKind.Utc).AddTicks(5707));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 280, DateTimeKind.Utc).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 861, DateTimeKind.Utc).AddTicks(6043));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 948, DateTimeKind.Utc).AddTicks(5210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 375, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.AddColumn<double>(
                name: "Rating",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 902, DateTimeKind.Utc).AddTicks(7704),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 323, DateTimeKind.Utc).AddTicks(6169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 875, DateTimeKind.Utc).AddTicks(1480),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 299, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 952, DateTimeKind.Utc).AddTicks(5707),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 378, DateTimeKind.Utc).AddTicks(3326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 8, 5, 18, 37, 861, DateTimeKind.Utc).AddTicks(6043),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 280, DateTimeKind.Utc).AddTicks(1210));
        }
    }
}
