using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenoshobeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class NewDbUpdate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Is_active",
                table: "Products",
                newName: "IsAvailable");

            migrationBuilder.RenameColumn(
                name: "Av_in_stock",
                table: "Products",
                newName: "numberOfItemsInStock");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "creditCarts",
                type: "nvarchar(16)",
                maxLength: 16,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(12)",
                oldMaxLength: 12);

            migrationBuilder.AddColumn<decimal>(
                name: "Balance",
                table: "creditCarts",
                type: "decimal(18,2)",
                nullable: false,
                defaultValue: 0m);

            migrationBuilder.AddColumn<int>(
                name: "OrderId",
                table: "creditCarts",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_creditCarts_OrderId",
                table: "creditCarts",
                column: "OrderId");

            migrationBuilder.AddForeignKey(
                name: "FK_creditCarts_Orders_OrderId",
                table: "creditCarts",
                column: "OrderId",
                principalTable: "Orders",
                principalColumn: "OrderId",
                onDelete: ReferentialAction.NoAction);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_creditCarts_Orders_OrderId",
                table: "creditCarts");

            migrationBuilder.DropIndex(
                name: "IX_creditCarts_OrderId",
                table: "creditCarts");

            migrationBuilder.DropColumn(
                name: "Balance",
                table: "creditCarts");

            migrationBuilder.DropColumn(
                name: "OrderId",
                table: "creditCarts");

            migrationBuilder.RenameColumn(
                name: "numberOfItemsInStock",
                table: "Products",
                newName: "Av_in_stock");

            migrationBuilder.RenameColumn(
                name: "IsAvailable",
                table: "Products",
                newName: "Is_active");

            migrationBuilder.AlterColumn<string>(
                name: "CardNumber",
                table: "creditCarts",
                type: "nvarchar(12)",
                maxLength: 12,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "nvarchar(16)",
                oldMaxLength: 16);
        }
    }
}
