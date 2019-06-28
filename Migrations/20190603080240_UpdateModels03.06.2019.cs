using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdateModels03062019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityUserId",
                table: "RefuelingsSensor",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefuelingsSensor_IdentityUserId",
                table: "RefuelingsSensor",
                column: "IdentityUserId");

            migrationBuilder.AddForeignKey(
                name: "FK_RefuelingsSensor_AspNetUsers_IdentityUserId",
                table: "RefuelingsSensor",
                column: "IdentityUserId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RefuelingsSensor_AspNetUsers_IdentityUserId",
                table: "RefuelingsSensor");

            migrationBuilder.DropIndex(
                name: "IX_RefuelingsSensor_IdentityUserId",
                table: "RefuelingsSensor");

            migrationBuilder.DropColumn(
                name: "IdentityUserId",
                table: "RefuelingsSensor");
        }
    }
}
