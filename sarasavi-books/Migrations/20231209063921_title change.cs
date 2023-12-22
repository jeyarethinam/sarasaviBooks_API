using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace sarasavi_books.Migrations
{
    /// <inheritdoc />
    public partial class titlechange : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Name",
                table: "books",
                newName: "Title");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Title",
                table: "books",
                newName: "Name");
        }
    }
}
