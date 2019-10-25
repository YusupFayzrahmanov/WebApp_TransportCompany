using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingReports_Trucks_TruckId",
                table: "RefuelingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Trucks_TruckId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Drivers_DriverId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Drivers_DriverId",
                table: "Salaries");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Salaries",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Reports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Repairs",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingReports",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingReports_Trucks_TruckId",
                table: "RefuelingReports",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Trucks_TruckId",
                table: "Repairs",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Drivers_DriverId",
                table: "Reports",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Drivers_DriverId",
                table: "Salaries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingReports_Trucks_TruckId",
                table: "RefuelingReports");

            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_Trucks_TruckId",
                table: "Repairs");

            migrationBuilder.DropForeignKey(
                name: "FK_Reports_Drivers_DriverId",
                table: "Reports");

            migrationBuilder.DropForeignKey(
                name: "FK_Salaries_Drivers_DriverId",
                table: "Salaries");

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Salaries",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "DriverId",
                table: "Reports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "Repairs",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingReports",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingReports_Trucks_TruckId",
                table: "RefuelingReports",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_Trucks_TruckId",
                table: "Repairs",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Reports_Drivers_DriverId",
                table: "Reports",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_Salaries_Drivers_DriverId",
                table: "Salaries",
                column: "DriverId",
                principalTable: "Drivers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
