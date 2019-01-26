using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedVoteAveragePropertyForMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 328, DateTimeKind.Utc).AddTicks(2907),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 376, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.AddColumn<double>(
                name: "VoteAverage",
                table: "Movies",
                nullable: false,
                defaultValue: 0.0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 263, DateTimeKind.Utc).AddTicks(5333),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 315, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 235, DateTimeKind.Utc).AddTicks(6109),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 285, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 332, DateTimeKind.Utc).AddTicks(1500),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 379, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 218, DateTimeKind.Utc).AddTicks(6984),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 266, DateTimeKind.Utc).AddTicks(8482));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteAverage",
                table: "Movies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 376, DateTimeKind.Utc).AddTicks(8005),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 328, DateTimeKind.Utc).AddTicks(2907));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 315, DateTimeKind.Utc).AddTicks(8650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 263, DateTimeKind.Utc).AddTicks(5333));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 285, DateTimeKind.Utc).AddTicks(723),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 235, DateTimeKind.Utc).AddTicks(6109));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 379, DateTimeKind.Utc).AddTicks(5149),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 332, DateTimeKind.Utc).AddTicks(1500));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 266, DateTimeKind.Utc).AddTicks(8482),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 44, 218, DateTimeKind.Utc).AddTicks(6984));
        }
    }
}
