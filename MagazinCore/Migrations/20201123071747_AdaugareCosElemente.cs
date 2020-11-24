using Microsoft.EntityFrameworkCore.Migrations;

namespace MagazinCore.Migrations
{
    public partial class AdaugareCosElemente : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "CosElemente",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Cantitate = table.Column<int>(nullable: false),
                    CosId = table.Column<int>(nullable: false),
                    ProdusId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_CosElemente", x => x.Id);
                    table.ForeignKey(
                        name: "FK_CosElemente_Cos_CosId",
                        column: x => x.CosId,
                        principalTable: "Cos",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_CosElemente_Produs_ProdusId",
                        column: x => x.ProdusId,
                        principalTable: "Produs",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_CosElemente_CosId",
                table: "CosElemente",
                column: "CosId");

            migrationBuilder.CreateIndex(
                name: "IX_CosElemente_ProdusId",
                table: "CosElemente",
                column: "ProdusId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "CosElemente");
        }
    }
}
