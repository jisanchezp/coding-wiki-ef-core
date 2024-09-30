using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CodingWiki.DataAccess.Migrations
{
    /// <inheritdoc />
    public partial class RenamedDescriptionColumnInGenreToDisplayOrder : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Genres",
                newName: "DisplayOrder");

            /* 
             * If .NET version < .NET 5 and you want to rename a column 
             * You should use the following statement:
             * 
             * migrationBuilder.Sql(UPDATE dbo.genres SET Display=DisplayOrder);
             * 
             */
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "DisplayOrder",
                table: "Genres",
                newName: "Description");
        }
    }
}
