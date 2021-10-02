using Microsoft.EntityFrameworkCore.Migrations;

namespace MoneyManager.Migrations
{
    public partial class editExpendModel : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Price",
                table: "Expenses",
                newName: "Amount");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(
                name: "Amount",
                table: "Expenses",
                newName: "Price");
        }
    }
}
