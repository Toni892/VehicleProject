using Microsoft.EntityFrameworkCore.Migrations;

namespace project.service.Migrations
{
    public partial class aaasd : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Vehicles_MakeId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels");

            migrationBuilder.AddColumn<int>(
                name: "VehicleMakeId",
                table: "VehicleModels",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropIndex(
                name: "IX_VehicleModels_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.CreateIndex(
                name: "IX_VehicleModels_MakeId",
                table: "VehicleModels",
                column: "MakeId");

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Vehicles_MakeId",
                table: "VehicleModels",
                column: "MakeId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
