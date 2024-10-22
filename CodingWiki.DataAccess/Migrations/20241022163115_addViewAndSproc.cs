using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class addViewAndSproc : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetMainBookDetails
             AS
            SELECT b.ISBN, b.Title, b.Price FROM dbo.Books b");

            migrationBuilder.Sql(@"CREATE OR ALTER VIEW dbo.GetAllBookDetails
             AS
            SELECT b.* FROM dbo.Books b");

            migrationBuilder.Sql(@"CREATE PROCEDURE dbo.SP_GetAllBookDetails
                    @bookId int                
                AS
                    SET NOCOUNT ON;
                    SELECT * FROM dbo.Books b
                    WHERE b.Id = @bookId
                GO");            
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DROP VIEW dbo.GetMainBookDetails");
            migrationBuilder.Sql("DROP VIEW dbo.GetAllBookDetails");
            migrationBuilder.Sql("DROP PROCEDURE dbo.SP_GetAllBookDetails");
        }
    }
}
