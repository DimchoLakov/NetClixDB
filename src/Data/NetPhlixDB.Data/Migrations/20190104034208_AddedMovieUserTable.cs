using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedMovieUserTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Movies_AspNetUsers_UserId",
                table: "Movies");

            migrationBuilder.DropIndex(
                name: "IX_Movies_UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "UserId",
                table: "Movies");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MoviePeople");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieGenres");

            migrationBuilder.DropColumn(
                name: "Id",
                table: "MovieCompanies");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 395, DateTimeKind.Utc).AddTicks(8195),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 570, DateTimeKind.Utc).AddTicks(8679));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 323, DateTimeKind.Utc).AddTicks(4750),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 498, DateTimeKind.Utc).AddTicks(784));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 398, DateTimeKind.Utc).AddTicks(5144),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 574, DateTimeKind.Utc).AddTicks(2676));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 308, DateTimeKind.Utc).AddTicks(6013),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 483, DateTimeKind.Utc).AddTicks(9643));

            migrationBuilder.CreateTable(
                name: "MovieUsers",
                columns: table => new
                {
                    MovieId = table.Column<string>(nullable: false),
                    UserId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_MovieUsers", x => new { x.MovieId, x.UserId });
                    table.ForeignKey(
                        name: "FK_MovieUsers_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_MovieUsers_AspNetUsers_UserId",
                        column: x => x.UserId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_MovieUsers_UserId",
                table: "MovieUsers",
                column: "UserId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "MovieUsers");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 570, DateTimeKind.Utc).AddTicks(8679),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 395, DateTimeKind.Utc).AddTicks(8195));

            migrationBuilder.AddColumn<string>(
                name: "UserId",
                table: "Movies",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MoviePeople",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MovieGenres",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Id",
                table: "MovieCompanies",
                nullable: true);

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 498, DateTimeKind.Utc).AddTicks(784),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 323, DateTimeKind.Utc).AddTicks(4750));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 574, DateTimeKind.Utc).AddTicks(2676),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 398, DateTimeKind.Utc).AddTicks(5144));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2018, 12, 26, 6, 44, 19, 483, DateTimeKind.Utc).AddTicks(9643),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 4, 3, 42, 7, 308, DateTimeKind.Utc).AddTicks(6013));

            migrationBuilder.CreateIndex(
                name: "IX_Movies_UserId",
                table: "Movies",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Movies_AspNetUsers_UserId",
                table: "Movies",
                column: "UserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
