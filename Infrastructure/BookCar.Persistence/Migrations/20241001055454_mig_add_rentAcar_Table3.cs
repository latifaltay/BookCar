﻿using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace BookCar.Persistence.Migrations
{
    /// <inheritdoc />
    public partial class mig_add_rentAcar_Table3 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars");

            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_RentACars_RentACarId1",
                table: "RentACars");

            migrationBuilder.DropIndex(
                name: "IX_RentACars_RentACarId1",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "PickUpLocationId",
                table: "RentACars");

            migrationBuilder.DropColumn(
                name: "RentACarId1",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "LocationId",
                table: "RentACars",
                newName: "LocationID");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_LocationId",
                table: "RentACars",
                newName: "IX_RentACars_LocationID");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars",
                column: "LocationID",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RentACars_Locations_LocationID",
                table: "RentACars");

            migrationBuilder.RenameColumn(
                name: "LocationID",
                table: "RentACars",
                newName: "LocationId");

            migrationBuilder.RenameIndex(
                name: "IX_RentACars_LocationID",
                table: "RentACars",
                newName: "IX_RentACars_LocationId");

            migrationBuilder.AddColumn<int>(
                name: "PickUpLocationId",
                table: "RentACars",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "RentACarId1",
                table: "RentACars",
                type: "int",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RentACars_RentACarId1",
                table: "RentACars",
                column: "RentACarId1");

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_Locations_LocationId",
                table: "RentACars",
                column: "LocationId",
                principalTable: "Locations",
                principalColumn: "LocationId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RentACars_RentACars_RentACarId1",
                table: "RentACars",
                column: "RentACarId1",
                principalTable: "RentACars",
                principalColumn: "RentACarId");
        }
    }
}
