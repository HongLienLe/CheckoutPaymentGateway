using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class UpdatedModels : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Merchants_MerchantId",
                table: "PaymentRequests");

            migrationBuilder.DropColumn(
                name: "payment_type",
                table: "PaymentRequests");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "PaymentRequests",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Merchants_MerchantId",
                table: "PaymentRequests",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_PaymentRequests_Merchants_MerchantId",
                table: "PaymentRequests");

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "PaymentRequests",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddColumn<int>(
                name: "payment_type",
                table: "PaymentRequests",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_PaymentRequests_Merchants_MerchantId",
                table: "PaymentRequests",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
