using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace VistoriaDeVeiculos.Migrations
{
    public partial class MyFirstMigration : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "FormularioDeInspecao",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PeriodicalSemanal = table.Column<string>(type: "varchar(50)", nullable: true),
                    TipoDeTranferencia = table.Column<string>(type: "varchar(50)", nullable: true),
                    DadosDoFormulario_Obra = table.Column<string>(nullable: true),
                    DadosDoFormulario_DataDaInspecao = table.Column<string>(nullable: true),
                    DadosDoFormulario_NumeroDoFormulario = table.Column<string>(nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_FormularioDeInspecao", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Motorista",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CNH = table.Column<string>(type: "varchar(50)", nullable: false),
                    Categoria = table.Column<string>(type: "varchar(50)", nullable: false),
                    FormularioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Motorista", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Motorista_FormularioDeInspecao_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "FormularioDeInspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Pergunta",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Titulo = table.Column<string>(type: "varchar(50)", nullable: false),
                    Descricao = table.Column<string>(type: "varchar(300)", nullable: true),
                    Resposta = table.Column<string>(type: "varchar(50)", nullable: false),
                    FormularioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Pergunta", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Pergunta_FormularioDeInspecao_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "FormularioDeInspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Veiculo",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Placa = table.Column<string>(type: "varchar(50)", nullable: false),
                    UltimaRevisao = table.Column<string>(type: "varchar(50)", nullable: false),
                    FormularioId = table.Column<Guid>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Veiculo", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Veiculo_FormularioDeInspecao_FormularioId",
                        column: x => x.FormularioId,
                        principalTable: "FormularioDeInspecao",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_Motorista_FormularioId",
                table: "Motorista",
                column: "FormularioId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Pergunta_FormularioId",
                table: "Pergunta",
                column: "FormularioId");

            migrationBuilder.CreateIndex(
                name: "IX_Veiculo_FormularioId",
                table: "Veiculo",
                column: "FormularioId",
                unique: true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Motorista");

            migrationBuilder.DropTable(
                name: "Pergunta");

            migrationBuilder.DropTable(
                name: "Veiculo");

            migrationBuilder.DropTable(
                name: "FormularioDeInspecao");
        }
    }
}
