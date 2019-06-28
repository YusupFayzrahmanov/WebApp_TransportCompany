using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdateModels3Migration29052019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsCheck_Drivers_DriverId",
                table: "RefuelingsCheck");

            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsSensor_Drivers_DriverId",
                table: "RefuelingsSensor");

            migrationBuilder.DropIndex(
                name: "IX_RefuelingsSensor_DriverId",
                table: "RefuelingsSensor");

            migrationBuilder.DropIndex(
                name: "IX_RefuelingsCheck_DriverId",
                table: "RefuelingsCheck");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "RefuelingsSensor");

            migrationBuilder.DropColumn(
                name: "DriverId",
                table: "RefuelingsCheck");

            migrationBuilder.AddColumn<string>(
                name: "RegistrationCertificate",
                table: "Trucks",
                nullable: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RegistrationCertificate",
                table: "Trucks");

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "RefuelingsSensor",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "DriverId",
                table: "RefuelingsCheck",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefuelingsSensor_DriverId",
                table: "RefuelingsSensor",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_RefuelingsCheck_DriverId",
                table: "RefuelingsCheck",
                column: "DriverId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsCheck_Drivers_DriverId",
                table: "RefuelingsCheck",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsSensor_Drivers_DriverId",
                table: "RefuelingsSensor",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
