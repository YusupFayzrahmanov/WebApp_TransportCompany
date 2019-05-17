using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdateDriverModelMigration14052019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "Drivers",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Drivers_IdentityId",
                table: "Drivers",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_Drivers_AspNetUsers_IdentityId",
                table: "Drivers",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Drivers_AspNetUsers_IdentityId",
                table: "Drivers");

            migrationBuilder.DropIndex(
                name: "IX_Drivers_IdentityId",
                table: "Drivers");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "Drivers");
        }
    }
}
