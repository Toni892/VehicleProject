using Microsoft.EntityFrameworkCore.Migrations;

namespace project.service.Migrations
{
    public partial class dodaoabrv : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Abrv",
                table: "Vehicles",
                nullable: true);

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleModels",
                nullable: false,
                oldClrType: typeof(string),
                oldNullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Abrv",
                table: "VehicleModels",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Abrv",
                table: "Vehicles");

            migrationBuilder.DropColumn(
                name: "Abrv",
                table: "VehicleModels");

            migrationBuilder.AlterColumn<string>(
                name: "Name",
                table: "VehicleModels",
                nullable: true,
                oldClrType: typeof(string));
        }
    }
}
