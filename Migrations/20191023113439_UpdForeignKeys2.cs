using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdForeignKeys2 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsCheck_Trucks_TruckId",
                table: "RefuelingsCheck");

            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsSensor_Trucks_TruckId",
                table: "RefuelingsSensor");

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingsSensor",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingsCheck",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsCheck_Trucks_TruckId",
                table: "RefuelingsCheck",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsSensor_Trucks_TruckId",
                table: "RefuelingsSensor",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.SetNull);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsCheck_Trucks_TruckId",
                table: "RefuelingsCheck");

            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsSensor_Trucks_TruckId",
                table: "RefuelingsSensor");

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingsSensor",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "TruckId",
                table: "RefuelingsCheck",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsCheck_Trucks_TruckId",
                table: "RefuelingsCheck",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsSensor_Trucks_TruckId",
                table: "RefuelingsSensor",
                column: "TruckId",
                principalTable: "Trucks",
                principalColumn: "Id",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
