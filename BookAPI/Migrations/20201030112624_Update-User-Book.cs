using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace BookAPI.Migrations
{
    public partial class UpdateUserBook : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<DateTime>(
                name: "CreationDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<DateTime>(
                name: "UpdateDate",
                table: "Users",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "Authors",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Description",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn_10",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Isbn_13",
                table: "Book",
                nullable: true);

            migrationBuilder.AddColumn<DateTime>(
                name: "PublishedDate",
                table: "Book",
                nullable: false,
                defaultValue: new DateTime(1, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified));

            migrationBuilder.AddColumn<string>(
                name: "smallThumbnail",
                table: "Book",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "CreationDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "UpdateDate",
                table: "Users");

            migrationBuilder.DropColumn(
                name: "Authors",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Description",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Isbn_10",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "Isbn_13",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "PublishedDate",
                table: "Book");

            migrationBuilder.DropColumn(
                name: "smallThumbnail",
                table: "Book");
        }
    }
}
