using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class FluentValidationsAPIAdded : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author");

            migrationBuilder.RenameTable(
                name: "Fluent_Author",
                newName: "FluentAuthors");

            migrationBuilder.AddPrimaryKey(
                name: "PK_FluentAuthors",
                table: "FluentAuthors",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_FluentAuthors_Author_Id",
                table: "FluentBookAuthorMap",
                column: "Author_Id",
                principalTable: "FluentAuthors",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookAuthorMap_FluentAuthors_Author_Id",
                table: "FluentBookAuthorMap");

            migrationBuilder.DropPrimaryKey(
                name: "PK_FluentAuthors",
                table: "FluentAuthors");

            migrationBuilder.RenameTable(
                name: "FluentAuthors",
                newName: "Fluent_Author");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Fluent_Author",
                table: "Fluent_Author",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                table: "FluentBookAuthorMap",
                column: "Author_Id",
                principalTable: "Fluent_Author",
                principalColumn: "Author_Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
