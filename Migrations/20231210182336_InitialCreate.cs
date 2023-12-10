using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace CargoCompany.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId");

            migrationBuilder.AddForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations",
                column: "CarrierId",
                principalTable: "Carriers",
                principalColumn: "CarrierId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_CarrierConfigurations_Carriers_CarrierId",
                table: "CarrierConfigurations");

            migrationBuilder.DropIndex(
                name: "IX_CarrierConfigurations_CarrierId",
                table: "CarrierConfigurations");
        }
    }
}
