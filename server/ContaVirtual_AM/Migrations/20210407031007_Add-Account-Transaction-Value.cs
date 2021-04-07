using Microsoft.EntityFrameworkCore.Migrations;

namespace ContaVirtual_AM.Migrations
{
    public partial class AddAccountTransactionValue : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<decimal>(
                name: "Value",
                table: "Transactions",
                type: "Decimal",
                nullable: false,
                defaultValue: 0m);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Value",
                table: "Transactions");
        }
    }
}
