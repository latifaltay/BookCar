using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_update_blog_entity : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Description",
                table: "Blogs",
                newName: "BlogDescription");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "BlogDescription",
                table: "Blogs",
                newName: "Description");
        }
    }
}
