using Microsoft.EntityFrameworkCore.Migrations;

namespace WebApp_TransportCompany.Migrations
{
    public partial class Migration202062019 : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "TatneftCardId",
                table: "Trucks",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Trucks_TatneftCardId",
                table: "Trucks",
                column: "TatneftCardId");

            migrationBuilder.AddForeignKey(
                name: "FK_Trucks_TatneftCards_TatneftCardId",
                table: "Trucks",
                column: "TatneftCardId",
                principalTable: "TatneftCards",
                principalColumn: "Id",
                onDelete: ReferentialAction.Restrict);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Trucks_TatneftCards_TatneftCardId",
                table: "Trucks");

            migrationBuilder.DropIndex(
                name: "IX_Trucks_TatneftCardId",
                table: "Trucks");

            migrationBuilder.DropColumn(
                name: "TatneftCardId",
                table: "Trucks");
        }
    }
}
