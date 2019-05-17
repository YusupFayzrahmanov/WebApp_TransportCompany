using System;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class AddModelsMigration15052019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "RepairType",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Wheels",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Trucks",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Salaries",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Reports",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "RepairTypeId",
                table: "Repairs",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Orders",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "Note",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateTable(
                name: "Fines",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Date = table.Column<DateTime>(nullable: false),
                    Amount = table.Column<decimal>(nullable: false),
                    TruckId = table.Column<int>(nullable: true),
                    DriverId = table.Column<int>(nullable: true),
                    Principle = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Fines", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Fines_Drivers_DriverId",
                        column: x => x.DriverId,
                        principalTable: "Drivers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Fines_Trucks_TruckId",
                        column: x => x.TruckId,
                        principalTable: "Trucks",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RepairTypes",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("MySql:ValueGenerationStrategy", MySqlValueGenerationStrategy.IdentityColumn),
                    Name = table.Column<string>(nullable: true),
                    KilometersResource = table.Column<decimal>(nullable: true),
                    TimeResource = table.Column<TimeSpan>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RepairTypes", x => x.Id);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_DriverId",
                table: "Fines",
                column: "DriverId");

            migrationBuilder.CreateIndex(
                name: "IX_Fines_TruckId",
                table: "Fines",
                column: "TruckId");

            migrationBuilder.AddForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs",
                column: "RepairTypeId",
                principalTable: "RepairTypes",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Repairs_RepairTypes_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropTable(
                name: "Fines");

            migrationBuilder.DropTable(
                name: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_Repairs_RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Wheels");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Salaries");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Reports");

            migrationBuilder.DropColumn(
                name: "RepairTypeId",
                table: "Repairs");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Orders");

            migrationBuilder.DropColumn(
                name: "Note",
                table: "Drivers");

            migrationBuilder.AddColumn<int>(
                name: "RepairType",
                table: "Repairs",
                nullable: false,
                defaultValue: 0);
        }
    }
}
