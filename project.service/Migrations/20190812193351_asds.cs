using Microsoft.EntityFrameworkCore.Migrations;

namespace project.service.Migrations
{
    public partial class asds : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MakeId",
                table: "VehicleModels");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "MakeId",
                table: "VehicleModels",
                nullable: false,
                defaultValue: 0);
        }
    }
}
