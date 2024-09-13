using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_update4 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PricindId",
                table: "CarPricings");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PricindId",
                table: "CarPricings",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
