using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class Migration02062019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "PreviousRepairDate",
                table: "Repairs");

            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "TatneftCards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_TatneftCards_IdentityId",
                table: "TatneftCards",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_TatneftCards_AspNetUsers_IdentityId",
                table: "TatneftCards",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_TatneftCards_AspNetUsers_IdentityId",
                table: "TatneftCards");

            migrationBuilder.DropIndex(
                name: "IX_TatneftCards_IdentityId",
                table: "TatneftCards");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "TatneftCards");

            migrationBuilder.AddColumn<DateTime>(
                name: "PreviousRepairDate",
                table: "Repairs",
                nullable: true);
        }
    }
}
