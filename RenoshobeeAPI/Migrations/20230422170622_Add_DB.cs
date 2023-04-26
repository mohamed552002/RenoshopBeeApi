using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenoshobeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class Add_DB : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Products",
                columns: table => new
                {
                    ID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Price = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    Seller_Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Av_in_stock = table.Column<int>(type: "int", nullable: false),
                    Category = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Created_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    NumOfSales = table.Column<int>(type: "int", nullable: false),
                    Last_updated_at = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Img_url = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Is_active = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Products", x => x.ID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Products");
        }
    }
}
