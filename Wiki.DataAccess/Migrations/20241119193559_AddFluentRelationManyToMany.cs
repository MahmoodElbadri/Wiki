using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentRelationManyToMany : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMap");

            migrationBuilder.AddColumn<int>(
                name: "Publisher_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Book_Id", "Author_Id" });

            migrationBuilder.CreateTable(
                name: "FluentBookAuthorMap",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false),
                    Author_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthorMap", x => new { x.Book_Id, x.Author_Id });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_Fluent_Author_Author_Id",
                        column: x => x.Author_Id,
                        principalTable: "Fluent_Author",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_Fluent_Book_Book_Id",
                        column: x => x.Book_Id,
                        principalTable: "Fluent_Book",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id");

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap",
                column: "Author_Id");

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthorMap_Author_Id",
                table: "FluentBookAuthorMap",
                column: "Author_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book",
                column: "Publisher_Id",
                principalTable: "Fluent_Publisher",
                principalColumn: "Publisher_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_Publisher_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropTable(
                name: "FluentBookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap");

            migrationBuilder.DropIndex(
                name: "IX_BookAuthorMap_Author_Id",
                table: "BookAuthorMap");

            migrationBuilder.DropColumn(
                name: "Publisher_Id",
                table: "Fluent_Book");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BookAuthorMap",
                table: "BookAuthorMap",
                columns: new[] { "Author_Id", "Book_Id" });

            migrationBuilder.CreateIndex(
                name: "IX_BookAuthorMap_Book_Id",
                table: "BookAuthorMap",
                column: "Book_Id");
        }
    }
}
