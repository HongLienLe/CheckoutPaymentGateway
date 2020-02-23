using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class renamedMerchantPropertiesNameToLowerAndUpperBoundAmount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Merchants_MerchantId",
                table: "Customers");

            migrationBuilder.DropColumn(
                name: "LowerBound",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "UpperBound",
                table: "Merchants");

            migrationBuilder.AddColumn<int>(
                name: "LowerBoundAmount",
                table: "Merchants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperBoundAmount",
                table: "Merchants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MerchantId",
                table: "Cards",
                nullable: true);

            migrationBuilder.CreateIndex(
                name: "IX_Cards_MerchantId",
                table: "Cards",
                column: "MerchantId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId");

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Merchants_MerchantId",
                table: "Customers",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards");

            migrationBuilder.DropForeignKey(
                name: "FK_Customers_Merchants_MerchantId",
                table: "Customers");

            migrationBuilder.DropIndex(
                name: "IX_Cards_MerchantId",
                table: "Cards");

            migrationBuilder.DropColumn(
                name: "LowerBoundAmount",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "UpperBoundAmount",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "MerchantId",
                table: "Cards");

            migrationBuilder.AddColumn<int>(
                name: "LowerBound",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperBound",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Customers_CustomerId",
                table: "Cards",
                column: "CustomerId",
                principalTable: "Customers",
                principalColumn: "CustomerId",
                onDelete: ReferentialAction.Restrict);

            migrationBuilder.AddForeignKey(
                name: "FK_Customers_Merchants_MerchantId",
                table: "Customers",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
