using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace NetPhlixDB.Data.Migrations
{
    public partial class RemovedDirectorColRenamedEventColsAddedArticlesTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Director",
                table: "Movies");

            migrationBuilder.RenameColumn(
                name: "EventTitle",
                table: "Events",
                newName: "Title");

            migrationBuilder.RenameColumn(
                name: "EventPicture",
                table: "Events",
                newName: "Picture");

            migrationBuilder.RenameColumn(
                name: "EventInfo",
                table: "Events",
                newName: "Info");

            migrationBuilder.AlterColumn<int>(
                name: "Language",
                table: "Movies",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.CreateTable(
                name: "Article",
                columns: table => new
                {
                    Id = table.Column<string>(nullable: false),
                    Title = table.Column<string>(nullable: true),
                    Image = table.Column<string>(nullable: true),
                    CreatedOn = table.Column<DateTime>(nullable: false),
                    Content = table.Column<string>(nullable: true),
                    AuthorId = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Article", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Article_AspNetUsers_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "AspNetUsers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Article_AuthorId",
                table: "Article",
                column: "AuthorId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Article");

            migrationBuilder.RenameColumn(
                name: "Title",
                table: "Events",
                newName: "EventTitle");

            migrationBuilder.RenameColumn(
                name: "Picture",
                table: "Events",
                newName: "EventPicture");

            migrationBuilder.RenameColumn(
                name: "Info",
                table: "Events",
                newName: "EventInfo");

            migrationBuilder.AlterColumn<string>(
                name: "Language",
                table: "Movies",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<string>(
                name: "Director",
                table: "Movies",
                nullable: true);
        }
    }
}
