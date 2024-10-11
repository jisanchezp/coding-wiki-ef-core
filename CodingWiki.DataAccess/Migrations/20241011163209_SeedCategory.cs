using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class SeedCategory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 1', 0)");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 2', 0)");
            migrationBuilder.Sql("INSERT INTO Categories VALUES ('Cat 3', 0)");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        { 
        }
    }
}
