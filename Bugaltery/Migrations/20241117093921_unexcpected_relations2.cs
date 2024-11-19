using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bugaltery.Migrations
{
    /// <inheritdoc />
    public partial class unexcpected_relations2 : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Addresses_Residents_ResidentId",
                table: "Addresses");

            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Addresses_AddressId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Owners_AddressId",
                table: "Owners");

            migrationBuilder.DropIndex(
                name: "IX_Addresses_ResidentId",
                table: "Addresses");

            migrationBuilder.DropColumn(
                name: "AddressId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "ResidentId",
                table: "Addresses");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "AddressId",
                table: "Owners",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "ResidentId",
                table: "Addresses",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Owners_AddressId",
                table: "Owners",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ResidentId",
                table: "Addresses",
                column: "ResidentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Addresses_Residents_ResidentId",
                table: "Addresses",
                column: "ResidentId",
                principalTable: "Residents",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Addresses_AddressId",
                table: "Owners",
                column: "AddressId",
                principalTable: "Addresses",
                principalColumn: "Id");
        }
    }
}
