using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class AddMoreModelValidationsToModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Cards",
                maxLength: 1,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(max)",
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Cards",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldNullable: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Cascade);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards");

            migrationBuilder.AlterColumn<string>(
                name: "name",
                table: "Cards",
                type: "nvarchar(max)",
                nullable: true,
                oldClrType: typeof(string),
                oldMaxLength: 1);

            migrationBuilder.AlterColumn<int>(
                name: "MerchantId",
                table: "Cards",
                type: "int",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AddForeignKey(
                name: "FK_Cards_Merchants_MerchantId",
                table: "Cards",
                column: "MerchantId",
                principalTable: "Merchants",
                principalColumn: "MerchantId",
                onDelete: ReferentialAction.Restrict);
        }
    }
}
