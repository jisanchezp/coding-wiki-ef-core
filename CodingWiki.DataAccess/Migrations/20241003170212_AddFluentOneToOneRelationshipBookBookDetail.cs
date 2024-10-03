using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentOneToOneRelationshipBookBookDetail : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "BookId",
                table: "FluentBookDetails",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookDetails_BookId",
                table: "FluentBookDetails",
                column: "BookId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_BookId",
                table: "FluentBookDetails",
                column: "BookId",
                principalTable: "FluentBooks",
                principalColumn: "Book_Id",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_FluentBookDetails_FluentBooks_BookId",
                table: "FluentBookDetails");

            migrationBuilder.DropIndex(
                name: "IX_FluentBookDetails_BookId",
                table: "FluentBookDetails");

            migrationBuilder.DropColumn(
                name: "BookId",
                table: "FluentBookDetails");
        }
    }
}
