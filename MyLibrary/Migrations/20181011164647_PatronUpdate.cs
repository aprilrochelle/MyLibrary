using Microsoft.EntityFrameworkCore.Migrations;

namespace MyLibrary.Migrations
{
    public partial class PatronUpdate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "LibraryId",
                table: "Patron",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "LibraryId1",
                table: "Library",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Patron_LibraryId",
                table: "Patron",
                column: "LibraryId");

            migrationBuilder.CreateIndex(
                name: "IX_Library_LibraryId1",
                table: "Library",
                column: "LibraryId1");

            migrationBuilder.AddForeignKey(
                name: "FK_Library_Library_LibraryId1",
                table: "Library",
                column: "LibraryId1",
                principalTable: "Library",
                principalColumn: "LibraryId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Patron_Library_LibraryId",
                table: "Patron",
                column: "LibraryId",
                principalTable: "Library",
                principalColumn: "LibraryId",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Library_Library_LibraryId1",
                table: "Library");

            migrationBuilder.DropForeignKey(
                name: "FK_Patron_Library_LibraryId",
                table: "Patron");

            migrationBuilder.DropIndex(
                name: "IX_Patron_LibraryId",
                table: "Patron");

            migrationBuilder.DropIndex(
                name: "IX_Library_LibraryId1",
                table: "Library");

            migrationBuilder.DropColumn(
                name: "LibraryId",
                table: "Patron");

            migrationBuilder.DropColumn(
                name: "LibraryId1",
                table: "Library");
        }
    }
}
