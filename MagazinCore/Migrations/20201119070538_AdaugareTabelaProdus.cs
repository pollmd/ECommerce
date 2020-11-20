using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinCore.Migrations
{
    public partial class AdaugareTabelaProdus : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Produs",
                columns: table => new
                {
                    id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Denumire = table.Column<string>(nullable: true),
                    Descriere = table.Column<string>(nullable: true),
                    Cost = table.Column<float>(nullable: false),
                    Tva = table.Column<float>(nullable: false),
                    Acciz = table.Column<float>(nullable: false),
                    Marime = table.Column<string>(nullable: true),
                    Culoare = table.Column<string>(nullable: true),
                    Reducere = table.Column<float>(nullable: false),
                    StartReducere = table.Column<DateTime>(nullable: false),
                    EndReducere = table.Column<DateTime>(nullable: false),
                    Imagine = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Produs", x => x.id);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Produs");
        }
    }
}
