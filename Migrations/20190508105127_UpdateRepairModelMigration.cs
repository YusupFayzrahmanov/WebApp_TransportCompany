using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdateRepairModelMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_Repairs_RepairId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_RepairId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "RepairId",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_DriverId",
                table: "Repairs",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Drivers_DriverId",
                table: "Repairs",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Drivers_DriverId",
                table: "Repairs");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_DriverId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "Repairs");

            migrationBuilder.AddColumn<int>(
                name: "RepairId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_RepairId",
                table: "Drivers",
                column: "RepairId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_Repairs_RepairId",
                table: "Drivers",
                column: "RepairId",
                principalTable: "Repairs",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
