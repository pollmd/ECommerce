using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinCore.Migrations
{
    public partial class addquantity : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<int>(
                name: "Cantitate",
                table: "Produs",
                nullable: false,
                defaultValue: 0);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Cantitate",
                table: "Produs");
        }
    }
}
