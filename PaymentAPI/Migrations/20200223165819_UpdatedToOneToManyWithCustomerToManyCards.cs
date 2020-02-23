using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class UpdatedToOneToManyWithCustomerToManyCards : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_PaymentRequests_PaymentRequestId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards");

            migrationBuilder.DropIndex(
                name: "IX_Cards_PaymentRequestId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "PaymentRequestId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "PaymentRequests",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_PaymentRequests_CardId",
                table: "PaymentRequests",
                column: "CardId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Cards_CardId",
                table: "PaymentRequests",
                column: "CardId",
                principalTable: "Cards",
                principalColumn: "CardId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Cards_CardId",
                table: "PaymentRequests");

            migrationBuilder.DropIndex(
                name: "IX_PaymentRequests_CardId",
                table: "PaymentRequests");

            migrationBuilder.DropIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "CardId",
                table: "PaymentRequests");

            migrationBuilder.AddColumn<int>(
                name: "CardId",
                table: "Customers",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "PaymentRequestId",
                table: "Cards",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_CustomerId",
                table: "Cards",
                column: "CustomerId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_PaymentRequestId",
                table: "Cards",
                column: "PaymentRequestId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_PaymentRequests_PaymentRequestId",
                table: "Cards",
                column: "PaymentRequestId",
                principalTable: "PaymentRequests",
                principalColumn: "PaymentRequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
