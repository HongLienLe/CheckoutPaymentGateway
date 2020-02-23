using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class renameMerchantLowerAndUpperToMinAndMaxAount : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "LowerBoundAmount",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "UpperBoundAmount",
                table: "Merchants");

            migrationBuilder.AddColumn<int>(
                name: "MaxAmount",
                table: "Merchants",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "MinAmount",
                table: "Merchants",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "MaxAmount",
                table: "Merchants");

            migrationBuilder.DropColumn(
                name: "MinAmount",
                table: "Merchants");

            migrationBuilder.AddColumn<int>(
                name: "LowerBoundAmount",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "UpperBoundAmount",
                table: "Merchants",
                type: "int",
                nullable: false,
                defaultValue: 0);
        }
    }
}
