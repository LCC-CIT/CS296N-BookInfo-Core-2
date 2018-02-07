using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace BookInfo.Migrations
{
    public partial class AddFkToAuthor : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors");

            migrationBuilder.DropColumn(
                name: "AuthorID",
                table: "Books");

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Authors",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors");

            migrationBuilder.AddColumn<int>(
                name: "AuthorID",
                table: "Books",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AlterColumn<int>(
                name: "BookID",
                table: "Authors",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Authors_Books_BookID",
                table: "Authors",
                column: "BookID",
                principalTable: "Books",
                principalColumn: "BookID",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
