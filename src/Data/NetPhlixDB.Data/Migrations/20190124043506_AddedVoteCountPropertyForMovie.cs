using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedVoteCountPropertyForMovie : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 376, DateTimeKind.Utc).AddTicks(8005),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 375, DateTimeKind.Utc).AddTicks(6710));

            migrationBuilder.AddColumn<int>(
                name: "VoteCount",
                table: "Movies",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 315, DateTimeKind.Utc).AddTicks(8650),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 323, DateTimeKind.Utc).AddTicks(6169));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 285, DateTimeKind.Utc).AddTicks(723),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 299, DateTimeKind.Utc).AddTicks(9571));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 379, DateTimeKind.Utc).AddTicks(5149),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 378, DateTimeKind.Utc).AddTicks(3326));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 266, DateTimeKind.Utc).AddTicks(8482),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 280, DateTimeKind.Utc).AddTicks(1210));
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "VoteCount",
                table: "Movies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 375, DateTimeKind.Utc).AddTicks(6710),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 376, DateTimeKind.Utc).AddTicks(8005));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 323, DateTimeKind.Utc).AddTicks(6169),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 315, DateTimeKind.Utc).AddTicks(8650));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 299, DateTimeKind.Utc).AddTicks(9571),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 285, DateTimeKind.Utc).AddTicks(723));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 378, DateTimeKind.Utc).AddTicks(3326),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 379, DateTimeKind.Utc).AddTicks(5149));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 24, 4, 17, 1, 280, DateTimeKind.Utc).AddTicks(1210),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 24, 4, 35, 5, 266, DateTimeKind.Utc).AddTicks(8482));
        }
    }
}
