using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Bugaltery.Migrations
{
    /// <inheritdoc />
    public partial class unexcpected_relations : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Owners_Payments_PaymentId",
                table: "Owners");

            migrationBuilder.DropForeignKey(
                name: "FK_PaymentTypes_Payments_PaymentId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_PaymentTypes_PaymentId",
                table: "PaymentTypes");

            migrationBuilder.DropIndex(
                name: "IX_Owners_PaymentId",
                table: "Owners");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "PaymentTypes");

            migrationBuilder.DropColumn(
                name: "PaymentId",
                table: "Owners");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "PaymentTypes",
                type: "integer",
                nullable: true);

            migrationBuilder.AddColumn<int>(
                name: "PaymentId",
                table: "Owners",
                type: "integer",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentTypes_PaymentId",
                table: "PaymentTypes",
                column: "PaymentId");

            migrationBuilder.CreateIndex(
                name: "IX_Owners_PaymentId",
                table: "Owners",
                column: "PaymentId");

            migrationBuilder.AddForeignKey(
                name: "FK_Owners_Payments_PaymentId",
                table: "Owners",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentTypes_Payments_PaymentId",
                table: "PaymentTypes",
                column: "PaymentId",
                principalTable: "Payments",
                principalColumn: "Id");
        }
    }
}
