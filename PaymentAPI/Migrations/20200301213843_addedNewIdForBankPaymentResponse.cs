using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class addedNewIdForBankPaymentResponse : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankPaymentResponse_PaymentRequests_PaymentRequestId",
                table: "BankPaymentResponse");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPaymentResponse",
                table: "BankPaymentResponse");

            migrationBuilder.RenameTable(
                name: "BankPaymentResponse",
                newName: "BankPaymentResponses");

            migrationBuilder.RenameIndex(
                name: "IX_BankPaymentResponse_PaymentRequestId",
                table: "BankPaymentResponses",
                newName: "IX_BankPaymentResponses_PaymentRequestId");

            migrationBuilder.AddColumn<int>(
                name: "BankPaymentResponseId",
                table: "BankPaymentResponses",
                nullable: false,
                defaultValue: 0)
                .Annotation("SqlServer:Identity", "1, 1");

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "BankPaymentResponses",
                nullable: true);

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPaymentResponses",
                table: "BankPaymentResponses",
                column: "BankPaymentResponseId");

            migrationBuilder.CreateIndex(
                name: "IX_BankPaymentResponses_MerchantId",
                table: "BankPaymentResponses",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_BankPaymentResponses_Merchants_MerchantId",
                table: "BankPaymentResponses",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_BankPaymentResponses_PaymentRequests_PaymentRequestId",
                table: "BankPaymentResponses",
                column: "PaymentRequestId",
                principalTable: "PaymentRequests",
                principalColumn: "PaymentRequestId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_BankPaymentResponses_Merchants_MerchantId",
                table: "BankPaymentResponses");

            migrationBuilder.DropForeignKey(
                name: "FK_BankPaymentResponses_PaymentRequests_PaymentRequestId",
                table: "BankPaymentResponses");

            migrationBuilder.DropPrimaryKey(
                name: "PK_BankPaymentResponses",
                table: "BankPaymentResponses");

            migrationBuilder.DropIndex(
                name: "IX_BankPaymentResponses_MerchantId",
                table: "BankPaymentResponses");

            migrationBuilder.DropColumn(
                name: "BankPaymentResponseId",
                table: "BankPaymentResponses");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "BankPaymentResponses");

            migrationBuilder.RenameTable(
                name: "BankPaymentResponses",
                newName: "BankPaymentResponse");

            migrationBuilder.RenameIndex(
                name: "IX_BankPaymentResponses_PaymentRequestId",
                table: "BankPaymentResponse",
                newName: "IX_BankPaymentResponse_PaymentRequestId");

            migrationBuilder.AddPrimaryKey(
                name: "PK_BankPaymentResponse",
                table: "BankPaymentResponse",
                column: "Id");

            migrationBuilder.AddForeignKey(
                name: "FK_BankPaymentResponse_PaymentRequests_PaymentRequestId",
                table: "BankPaymentResponse",
                column: "PaymentRequestId",
                principalTable: "PaymentRequests",
                principalColumn: "PaymentRequestId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
