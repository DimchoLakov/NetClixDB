using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class AddedEventMoviesAndEventPeopleTables : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 808, DateTimeKind.Utc).AddTicks(6764),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 45, DateTimeKind.Utc).AddTicks(4301));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 743, DateTimeKind.Utc).AddTicks(1387),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 955, DateTimeKind.Utc).AddTicks(8086));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 708, DateTimeKind.Utc).AddTicks(3290),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 911, DateTimeKind.Utc).AddTicks(1737));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 813, DateTimeKind.Utc).AddTicks(3718),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 52, DateTimeKind.Utc).AddTicks(933));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 685, DateTimeKind.Utc).AddTicks(5787),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 878, DateTimeKind.Utc).AddTicks(1671));

            migrationBuilder.CreateTable(
                name: "EventMovies",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    MovieId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventMovies", x => new { x.EventId, x.MovieId });
                    table.ForeignKey(
                        name: "FK_EventMovies_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventMovies_Movies_MovieId",
                        column: x => x.MovieId,
                        principalTable: "Movies",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "EventPeople",
                columns: table => new
                {
                    EventId = table.Column<string>(nullable: false),
                    PersonId = table.Column<string>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EventPeople", x => new { x.EventId, x.PersonId });
                    table.ForeignKey(
                        name: "FK_EventPeople_Events_EventId",
                        column: x => x.EventId,
                        principalTable: "Events",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EventPeople_People_PersonId",
                        column: x => x.PersonId,
                        principalTable: "People",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_EventMovies_MovieId",
                table: "EventMovies",
                column: "MovieId");

            migrationBuilder.CreateIndex(
                name: "IX_EventPeople_PersonId",
                table: "EventPeople",
                column: "PersonId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EventMovies");

            migrationBuilder.DropTable(
                name: "EventPeople");

            migrationBuilder.AlterColumn<DateTime>(
                name: "DateAdded",
                table: "Reviews",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 45, DateTimeKind.Utc).AddTicks(4301),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 808, DateTimeKind.Utc).AddTicks(6764));

            migrationBuilder.AlterColumn<DateTime>(
                name: "Date",
                table: "Events",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 955, DateTimeKind.Utc).AddTicks(8086),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 743, DateTimeKind.Utc).AddTicks(1387));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Companies",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 911, DateTimeKind.Utc).AddTicks(1737),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 708, DateTimeKind.Utc).AddTicks(3290));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "AspNetUsers",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 43, 52, DateTimeKind.Utc).AddTicks(933),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 813, DateTimeKind.Utc).AddTicks(3718));

            migrationBuilder.AlterColumn<DateTime>(
                name: "CreatedOn",
                table: "Articles",
                nullable: false,
                defaultValue: new DateTime(2019, 1, 25, 1, 17, 42, 878, DateTimeKind.Utc).AddTicks(1671),
                oldClrType: typeof(DateTime),
                oldDefaultValue: new DateTime(2019, 2, 10, 17, 33, 59, 685, DateTimeKind.Utc).AddTicks(5787));
        }
    }
}
