using Microsoft.EntityFrameworkCore.Migrations;

namespace project.service.Migrations
{
    public partial class vehiclemakeid : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "VehicleModels");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleMakeId",
                table: "VehicleModels",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels");

            migrationBuilder.AlterColumn<int>(
                name: "VehicleMakeId",
                table: "VehicleModels",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "VehicleModels",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_VehicleModels_Vehicles_VehicleMakeId",
                table: "VehicleModels",
                column: "VehicleMakeId",
                principalTable: "Vehicles",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
