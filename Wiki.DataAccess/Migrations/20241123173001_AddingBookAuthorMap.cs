using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddingBookAuthorMap : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.RenameTable(
                name: "BookAuthorMap",
                newName: "BookAuthorMaps");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMaps",
                newName: "IX_BookAuthorMaps_Author_Id");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "BookDetails",
                type: "int",
                nullable: true,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Authors_Author_Id",
                table: "BookAuthorMaps",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMaps_Books_Book_Id",
                table: "BookAuthorMaps",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Authors_Author_Id",
                table: "BookAuthorMaps");

            migrationBuilder.DropForeignKey(
                name: "FK_BookAuthorMaps_Books_Book_Id",
                table: "BookAuthorMaps");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMaps",
                table: "BookAuthorMaps");

            migrationBuilder.RenameTable(
                name: "BookAuthorMaps",
                newName: "BookAuthorMap");

            migrationBuilder.RenameIndex(
                name: "IX_BookAuthorMaps_Author_Id",
                table: "BookAuthorMap",
                newName: "IX_BookAuthorMap_Author_Id");

            migrationBuilder.AlterColumn<int>(
                name: "NumberOfPages",
                table: "BookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Authors_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id",
                principalTable: "Authors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_BookAuthorMap_Books_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id",
                principalTable: "Books",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
