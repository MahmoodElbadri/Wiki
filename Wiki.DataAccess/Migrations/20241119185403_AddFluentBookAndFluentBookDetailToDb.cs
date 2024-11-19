using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Wiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentBookAndFluentBookDetailToDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetail_FluentBookDetailBookDetail_Id",
                table: "Fluent_Book");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_Book_FluentBookDetailBookDetail_Id",
                table: "Fluent_Book");

            migrationBuilder.DropColumn(
                name: "FluentBookDetailBookDetail_Id",
                table: "Fluent_Book");

            migrationBuilder.AddColumn<int>(
                name: "Book_Id",
                table: "Fluent_BookDetail",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_BookDetail_Book_Id",
                table: "Fluent_BookDetail",
                column: "Book_Id",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_BookDetail_Fluent_Book_Book_Id",
                table: "Fluent_BookDetail",
                column: "Book_Id",
                principalTable: "Fluent_Book",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Fluent_BookDetail_Fluent_Book_Book_Id",
                table: "Fluent_BookDetail");

            migrationBuilder.DropIndex(
                name: "IX_Fluent_BookDetail_Book_Id",
                table: "Fluent_BookDetail");

            migrationBuilder.DropColumn(
                name: "Book_Id",
                table: "Fluent_BookDetail");

            migrationBuilder.AddColumn<int>(
                name: "FluentBookDetailBookDetail_Id",
                table: "Fluent_Book",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Fluent_Book_FluentBookDetailBookDetail_Id",
                table: "Fluent_Book",
                column: "FluentBookDetailBookDetail_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Fluent_Book_Fluent_BookDetail_FluentBookDetailBookDetail_Id",
                table: "Fluent_Book",
                column: "FluentBookDetailBookDetail_Id",
                principalTable: "Fluent_BookDetail",
                principalColumn: "BookDetail_Id");
        }
    }
}
