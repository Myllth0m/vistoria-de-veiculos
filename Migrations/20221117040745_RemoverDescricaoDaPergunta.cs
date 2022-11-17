using Microsoft.EntityFrameworkCore.Migrations;

namespace VistoriaDeVeiculos.Migrations
{
    public partial class RemoverDescricaoDaPergunta : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Descricao",
                table: "Pergunta");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                name: "Descricao",
                table: "Pergunta",
                type: "varchar(300)",
                nullable: true);
        }
    }
}
