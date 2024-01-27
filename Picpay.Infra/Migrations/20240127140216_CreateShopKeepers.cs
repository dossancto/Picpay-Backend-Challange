using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picpay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateShopKeepers : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ShopKeepers",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Fullname = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Email = table.Column<string>(type: "character varying(255)", maxLength: 255, nullable: false),
                    CPF = table.Column<string>(type: "character varying(11)", maxLength: 11, nullable: false),
                    HashedPassword = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Salt = table.Column<string>(type: "character varying(128)", maxLength: 128, nullable: false),
                    Balance = table.Column<decimal>(type: "numeric", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ShopKeepers", x => x.Id);
                    table.CheckConstraint("CK_Users_Balance", "\"Balance\" > 0");
                });

            migrationBuilder.CreateIndex(
                name: "IX_ShopKeepers_CPF",
                table: "ShopKeepers",
                column: "CPF",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_ShopKeepers_Email",
                table: "ShopKeepers",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "ShopKeepers");
        }
    }
}
