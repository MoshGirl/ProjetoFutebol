using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFutebol.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class AdicionaNovasModals : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "AreaFilhas");

            migrationBuilder.DropTable(
                name: "Areas");

            migrationBuilder.CreateTable(
                name: "Equipes",
                columns: table => new
                {
                    EquipeID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeEquipe = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    NomeAbreviado = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    Escudo = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Equipes", x => x.EquipeID);
                });

            migrationBuilder.CreateTable(
                name: "Paises",
                columns: table => new
                {
                    PaisID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomePais = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(15)", maxLength: 15, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Paises", x => x.PaisID);
                });

            migrationBuilder.CreateTable(
                name: "Competicoes",
                columns: table => new
                {
                    CompeticaoID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    NomeCompeticao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(10)", maxLength: 10, nullable: false),
                    TipoCompeticao = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Temporada = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PaisID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Competicoes", x => x.CompeticaoID);
                    table.ForeignKey(
                        name: "FK_Competicoes_Paises_PaisID",
                        column: x => x.PaisID,
                        principalTable: "Paises",
                        principalColumn: "PaisID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "EquipesCompeticoes",
                columns: table => new
                {
                    EquipeID = table.Column<int>(type: "int", nullable: false),
                    CompeticaoID = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_EquipesCompeticoes", x => new { x.EquipeID, x.CompeticaoID });
                    table.ForeignKey(
                        name: "FK_EquipesCompeticoes_Competicoes_CompeticaoID",
                        column: x => x.CompeticaoID,
                        principalTable: "Competicoes",
                        principalColumn: "CompeticaoID",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_EquipesCompeticoes_Equipes_EquipeID",
                        column: x => x.EquipeID,
                        principalTable: "Equipes",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Partidas",
                columns: table => new
                {
                    PartidaID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    DataPartida = table.Column<DateTime>(type: "datetime2", nullable: false),
                    CompeticaoID = table.Column<int>(type: "int", nullable: false),
                    TimeDaCasaID = table.Column<int>(type: "int", nullable: false),
                    TimeVisitanteID = table.Column<int>(type: "int", nullable: false),
                    PlacarID = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Partidas", x => x.PartidaID);
                    table.ForeignKey(
                        name: "FK_Partidas_Competicoes_CompeticaoID",
                        column: x => x.CompeticaoID,
                        principalTable: "Competicoes",
                        principalColumn: "CompeticaoID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Equipes_TimeDaCasaID",
                        column: x => x.TimeDaCasaID,
                        principalTable: "Equipes",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_Partidas_Equipes_TimeVisitanteID",
                        column: x => x.TimeVisitanteID,
                        principalTable: "Equipes",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Placares",
                columns: table => new
                {
                    PlacarID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    PartidaID = table.Column<int>(type: "int", nullable: false),
                    VencedorID = table.Column<int>(type: "int", nullable: true),
                    PlacarVisitante = table.Column<int>(type: "int", nullable: false),
                    PlacarTimeDaCasa = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Placares", x => x.PlacarID);
                    table.ForeignKey(
                        name: "FK_Placares_Equipes_VencedorID",
                        column: x => x.VencedorID,
                        principalTable: "Equipes",
                        principalColumn: "EquipeID",
                        onDelete: ReferentialAction.SetNull);
                    table.ForeignKey(
                        name: "FK_Placares_Partidas_PartidaID",
                        column: x => x.PartidaID,
                        principalTable: "Partidas",
                        principalColumn: "PartidaID",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Competicoes_PaisID",
                table: "Competicoes",
                column: "PaisID");

            migrationBuilder.CreateIndex(
                name: "IX_EquipesCompeticoes_CompeticaoID",
                table: "EquipesCompeticoes",
                column: "CompeticaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_CompeticaoID",
                table: "Partidas",
                column: "CompeticaoID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeDaCasaID",
                table: "Partidas",
                column: "TimeDaCasaID");

            migrationBuilder.CreateIndex(
                name: "IX_Partidas_TimeVisitanteID",
                table: "Partidas",
                column: "TimeVisitanteID");

            migrationBuilder.CreateIndex(
                name: "IX_Placares_PartidaID",
                table: "Placares",
                column: "PartidaID",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Placares_VencedorID",
                table: "Placares",
                column: "VencedorID");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "EquipesCompeticoes");

            migrationBuilder.DropTable(
                name: "Placares");

            migrationBuilder.DropTable(
                name: "Partidas");

            migrationBuilder.DropTable(
                name: "Competicoes");

            migrationBuilder.DropTable(
                name: "Equipes");

            migrationBuilder.DropTable(
                name: "Paises");

            migrationBuilder.CreateTable(
                name: "Areas",
                columns: table => new
                {
                    AreaId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AreaPai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaPaiId = table.Column<int>(type: "int", nullable: true),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Codigo = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
                    AreaId = table.Column<int>(type: "int", nullable: true),
                    AreaPai = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AreaPaiId = table.Column<int>(type: "int", nullable: false),
                    Bandeira = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    CodigoPais = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false)
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
    }
}
