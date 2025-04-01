using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFutebol.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaPaiId = table.Column<int>(type: "int", nullable: true),
                    AreaPai = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Areas", x => x.AreaId);
                });

            migrationBuilder.CreateTable(
                name: "AreaFilhas",
                columns: table => new
                {
                    AreaFilhaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaPaiId = table.Column<int>(type: "int", nullable: false),
                    AreaPai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AreaFilhas", x => x.AreaFilhaId);
                    table.ForeignKey(
                        name: "FK_AreaFilhas_Areas_AreaId",
                        column: x => x.AreaId,
                        principalTable: "Areas",
                        principalColumn: "AreaId");
                });

            migrationBuilder.CreateIndex(
                name: "IX_AreaFilhas_AreaId",
                table: "AreaFilhas",
                column: "AreaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaFilhas");

            migrationBuilder.DropTable(
                name: "Areas");
        }
    }
}
