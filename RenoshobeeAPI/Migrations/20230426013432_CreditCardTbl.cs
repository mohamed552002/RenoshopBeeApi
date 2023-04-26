using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenoshobeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class CreditCardTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "creditCarts",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CardNumber = table.Column<string>(type: "nvarchar(12)", maxLength: 12, nullable: false),
                    CCV = table.Column<string>(type: "nvarchar(3)", maxLength: 3, nullable: false),
                    ExpireDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CustomerId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_creditCarts", x => x.Id);
                    table.ForeignKey(
                        name: "FK_creditCarts_customers_CustomerId",
                        column: x => x.CustomerId,
                        principalTable: "customers",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_creditCarts_CustomerId",
                table: "creditCarts",
                column: "CustomerId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "creditCarts");
        }
    }
}
