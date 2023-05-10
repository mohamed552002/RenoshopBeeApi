using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenoshobeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class reseed : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DBCC CHECKIDENT('[creditCarts]', RESEED, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
