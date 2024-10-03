using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class AddFluentManyToManyRelationshipBooksAuthorsManual : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentAuthorFluentBook");

            migrationBuilder.CreateTable(
                name: "FluentBookAuthorMap",
                columns: table => new
                {
                    BookId = table.Column<int>(type: "int", nullable: false),
                    AuthorId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentBookAuthorMap", x => new { x.BookId, x.AuthorId });
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_FluentAuthors_AuthorId",
                        column: x => x.AuthorId,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentBookAuthorMap_FluentBooks_BookId",
                        column: x => x.BookId,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentBookAuthorMap_AuthorId",
                table: "FluentBookAuthorMap",
                column: "AuthorId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "FluentBookAuthorMap");

            migrationBuilder.CreateTable(
                name: "FluentAuthorFluentBook",
                columns: table => new
                {
                    AuthorsAuthor_Id = table.Column<int>(type: "int", nullable: false),
                    BooksBook_Id = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FluentAuthorFluentBook", x => new { x.AuthorsAuthor_Id, x.BooksBook_Id });
                    table.ForeignKey(
                        name: "FK_FluentAuthorFluentBook_FluentAuthors_AuthorsAuthor_Id",
                        column: x => x.AuthorsAuthor_Id,
                        principalTable: "FluentAuthors",
                        principalColumn: "Author_Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_FluentAuthorFluentBook_FluentBooks_BooksBook_Id",
                        column: x => x.BooksBook_Id,
                        principalTable: "FluentBooks",
                        principalColumn: "Book_Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_FluentAuthorFluentBook_BooksBook_Id",
                table: "FluentAuthorFluentBook",
                column: "BooksBook_Id");
        }
    }
}
