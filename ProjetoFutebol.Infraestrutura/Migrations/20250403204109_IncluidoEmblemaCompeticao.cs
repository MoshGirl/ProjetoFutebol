using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace ProjetoFutebol.Infraestrutura.Migrations
{
    /// <inheritdoc />
    public partial class IncluidoEmblemaCompeticao : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Emblema",
                table: "Competicoes",
                type: "nvarchar(max)",
                nullable: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Emblema",
                table: "Competicoes");
        }
    }
}
