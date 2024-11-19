using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentBooksToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Fluent_Book",
                columns: table => new
                {
                    Book_Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Title = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ISBN = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    FluentBookDetailBookDetail_Id = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fluent_Book", x => x.Book_Id);
                    table.ForeignKey(
                        name: "FK_Fluent_Book_Fluent_BookDetail_FluentBookDetailBookDetail_Id",
                        column: x => x.FluentBookDetailBookDetail_Id,
                        principalTable: "Fluent_BookDetail",
                        principalColumn: "BookDetail_Id");
                });

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_FluentBookDetailBookDetail_Id",
                table: "Fluent_Book",
                column: "FluentBookDetailBookDetail_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Fluent_Book");
        }
    }
}
