using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_rentAcar_Table : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_pricings_PricingId",
                table: "CarPricings");

            migrationBuilder.DropPrimaryKey(
                name: "PK_pricings",
                table: "pricings");

            migrationBuilder.RenameTable(
                name: "pricings",
                newName: "Pricings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings",
                column: "PricingId");

            migrationBuilder.CreateTable(
                name: "RentACars",
                columns: table => new
                {
                    RentACarId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PickUpLocationId = table.Column<int>(type: "int", nullable: false),
                    LocationId = table.Column<int>(type: "int", nullable: false),
                    CarId = table.Column<int>(type: "int", nullable: false),
                    Available = table.Column<bool>(type: "bit", nullable: false),
                    RentACarId1 = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RentACars", x => x.RentACarId);
                    table.ForeignKey(
                        name: "FK_RentACars_Cars_CarId",
                        column: x => x.CarId,
                        principalTable: "Cars",
                        principalColumn: "CarId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentACars_Locations_LocationId",
                        column: x => x.LocationId,
                        principalTable: "Locations",
                        principalColumn: "LocationId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RentACars_RentACars_RentACarId1",
                        column: x => x.RentACarId1,
                        principalTable: "RentACars",
                        principalColumn: "RentACarId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_CarId",
                table: "RentACars",
                column: "CarId");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                column: "LocationId");

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_RentACarId1",
                table: "RentACars",
                column: "RentACarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_Pricings_PricingId",
                table: "CarPricings",
                column: "PricingId",
                principalTable: "Pricings",
                principalColumn: "PricingId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarPricings_Pricings_PricingId",
                table: "CarPricings");

            migrationBuilder.DropTable(
                name: "RentACars");

            migrationBuilder.DropPrimaryKey(
                name: "PK_Pricings",
                table: "Pricings");

            migrationBuilder.RenameTable(
                name: "Pricings",
                newName: "pricings");

            migrationBuilder.AddPrimaryKey(
                name: "PK_pricings",
                table: "pricings",
                column: "PricingId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarPricings_pricings_PricingId",
                table: "CarPricings",
                column: "PricingId",
                principalTable: "pricings",
                principalColumn: "PricingId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
