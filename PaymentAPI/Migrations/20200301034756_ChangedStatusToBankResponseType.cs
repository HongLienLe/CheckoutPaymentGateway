using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace PaymentAPI.Migrations
{
    public partial class ChangedStatusToBankResponseType : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "status",
                table: "PaymentRequests");

            migrationBuilder.CreateTable(
                name: "BankPaymentResponse",
                columns: table => new
                {
                    Id = table.Column<Guid>(nullable: false),
                    Status = table.Column<bool>(nullable: false),
                    PaymentRequestId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BankPaymentResponse", x => x.Id);
                    table.ForeignKey(
                        name: "FK_BankPaymentResponse_PaymentRequests_PaymentRequestId",
                        column: x => x.PaymentRequestId,
                        principalTable: "PaymentRequests",
                        principalColumn: "PaymentRequestId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_BankPaymentResponse_PaymentRequestId",
                table: "BankPaymentResponse",
                column: "PaymentRequestId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "BankPaymentResponse");

            migrationBuilder.AddColumn<bool>(
                name: "status",
                table: "PaymentRequests",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }
    }
}
