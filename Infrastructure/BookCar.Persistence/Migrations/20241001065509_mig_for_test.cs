using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_for_test : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerID",
                table: "RentACarProcess");

            migrationBuilder.RenameColumn(
                name: "CustomerID",
                table: "RentACarProcess",
                newName: "CustomerId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcess_CustomerID",
                table: "RentACarProcess",
                newName: "IX_RentACarProcess_CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerId",
                table: "RentACarProcess",
                column: "CustomerId",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerId",
                table: "RentACarProcess");

            migrationBuilder.RenameColumn(
                name: "CustomerId",
                table: "RentACarProcess",
                newName: "CustomerID");

            migrationBuilder.RenameIndex(
                name: "IX_RentACarProcess_CustomerId",
                table: "RentACarProcess",
                newName: "IX_RentACarProcess_CustomerID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACarProcess_Customer_CustomerID",
                table: "RentACarProcess",
                column: "CustomerID",
                principalTable: "Customer",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
