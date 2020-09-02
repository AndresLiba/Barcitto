using Microsoft.EntityFrameworkCore.Migrations;

namespace Barcitto.Migrations
{
    public partial class AddQuantity_Cart : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            

            migrationBuilder.AddColumn<int>(
                name: "Quantity",
                table: "ShoppingCartItems",
                nullable: false,
                defaultValue: 1);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Quantity",
                table: "ShoppingCartItems");

            
        }
    }
}
