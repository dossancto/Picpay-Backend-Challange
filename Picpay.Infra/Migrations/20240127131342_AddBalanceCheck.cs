using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picpay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class AddBalanceCheck : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddCheckConstraint(
                name: "CK_Users_Balance",
                table: "Users",
                sql: "\"Balance\" > 0");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropCheckConstraint(
                name: "CK_Users_Balance",
                table: "Users");
        }
    }
}
