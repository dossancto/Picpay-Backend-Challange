using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Picpay.Infra.Migrations
{
    /// <inheritdoc />
    public partial class CreateTransactionLogs : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Transations",
                columns: table => new
                {
                    Id = table.Column<string>(type: "character varying(40)", maxLength: 40, nullable: false),
                    Ammount = table.Column<decimal>(type: "numeric", nullable: false),
                    Sender = table.Column<string>(type: "text", nullable: false),
                    Receiver = table.Column<string>(type: "text", nullable: false),
                    EventType = table.Column<int>(type: "integer", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "timestamp with time zone", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Transations", x => x.Id);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Transations");
        }
    }
}
