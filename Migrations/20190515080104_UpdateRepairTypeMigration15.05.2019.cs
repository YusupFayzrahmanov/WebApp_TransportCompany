using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class UpdateRepairTypeMigration15052019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "IdentityId",
                table: "RepairTypes",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_RepairTypes_IdentityId",
                table: "RepairTypes",
                column: "IdentityId");

            migrationBuilder.AddForeignKey(
                name: "FK_RepairTypes_AspNetUsers_IdentityId",
                table: "RepairTypes",
                column: "IdentityId",
                principalTable: "AspNetUsers",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_RepairTypes_AspNetUsers_IdentityId",
                table: "RepairTypes");

            migrationBuilder.DropIndex(
                name: "IX_RepairTypes_IdentityId",
                table: "RepairTypes");

            migrationBuilder.DropColumn(
                name: "IdentityId",
                table: "RepairTypes");
        }
    }
}
