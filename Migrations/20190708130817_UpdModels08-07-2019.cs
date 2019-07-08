using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdModels08072019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeResource",
                table: "RepairTypes");

            migrationBuilder.AddColumn<int>(
                name: "TimeResourceMonth",
                table: "RepairTypes",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "TimeResourceMonth",
                table: "RepairTypes");

            migrationBuilder.AddColumn<TimeSpan>(
                name: "TimeResource",
                table: "RepairTypes",
                nullable: false,
                defaultValue: new TimeSpan(0, 0, 0, 0, 0));
        }
    }
}
