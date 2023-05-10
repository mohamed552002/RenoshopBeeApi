using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace RenoshobeeAPI.Migrations
{
    /// <inheritdoc />
    public partial class reseedCustomerAndAddress : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DBCC CHECKIDENT('[customers]', RESEED, 0);");
            migrationBuilder.Sql("DBCC CHECKIDENT('[Addresses]', RESEED, 0);");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
