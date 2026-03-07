using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Mapeamento.Infrastructure.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreateWith15Points : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "ESTADOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Sigla = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ESTADOS", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "PONTOS_TURISTICOS",
                columns: table => new
                {
                    Id = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Nome = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Descricao = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Localizacao = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Cidade = table.Column<string>(type: "nvarchar(60)", maxLength: 60, nullable: false),
                    EstadoId = table.Column<int>(type: "int", nullable: false),
                    DataCriacao = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Status = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PONTOS_TURISTICOS", x => x.Id);
                    table.ForeignKey(
                        name: "FK_PONTOS_TURISTICOS_ESTADOS_EstadoId",
                        column: x => x.EstadoId,
                        principalTable: "ESTADOS",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "ESTADOS",
                columns: new[] { "Id", "Nome", "Sigla" },
                values: new object[,]
                {
                    { 1, "Acre", "AC" },
                    { 2, "Alagoas", "AL" },
                    { 3, "Amapá", "AP" },
                    { 4, "Amazonas", "AM" },
                    { 5, "Bahia", "BA" },
                    { 6, "Ceará", "CE" },
                    { 7, "Distrito Federal", "DF" },
                    { 8, "Espírito Santo", "ES" },
                    { 9, "Goiás", "GO" },
                    { 10, "Maranhão", "MA" },
                    { 11, "Mato Grosso", "MT" },
                    { 12, "Mato Grosso do Sul", "MS" },
                    { 13, "Minas Gerais", "MG" },
                    { 14, "Pará", "PA" },
                    { 15, "Paraíba", "PB" },
                    { 16, "Paraná", "PR" },
                    { 17, "Pernambuco", "PE" },
                    { 18, "Piauí", "PI" },
                    { 19, "Rio de Janeiro", "RJ" },
                    { 20, "Rio Grande do Norte", "RN" },
                    { 21, "Rio Grande do Sul", "RS" },
                    { 22, "Rondônia", "RO" },
                    { 23, "Roraima", "RR" },
                    { 24, "Santa Catarina", "SC" },
                    { 25, "São Paulo", "SP" },
                    { 26, "Sergipe", "SE" },
                    { 27, "Tocantins", "TO" }
                });

            migrationBuilder.InsertData(
                table: "PONTOS_TURISTICOS",
                columns: new[] { "Id", "Cidade", "DataCriacao", "Descricao", "EstadoId", "Localizacao", "Nome", "Status" },
                values: new object[,]
                {
                    { 1, "Rio de Janeiro", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Estátua icônica de Jesus Cristo, uma das maravilhas do mundo moderno.", 19, "Topo do Morro do Corcovado", "Cristo Redentor", true },
                    { 2, "São Paulo", new DateTime(2024, 1, 1, 10, 0, 0, 0, DateTimeKind.Unspecified), "Principal centro financeiro e cultural de São Paulo, com museus e eventos.", 25, "Região Central da cidade", "Avenida Paulista", true },
                    { 3, "Santana do Riacho", new DateTime(2024, 1, 2, 11, 0, 0, 0, DateTimeKind.Unspecified), "Parque Nacional com cachoeiras, trilhas e biodiversidade exuberante.", 13, "MG-010, Serra do Cipó", "Serra do Cipó", true },
                    { 4, "Salvador", new DateTime(2024, 1, 3, 9, 0, 0, 0, DateTimeKind.Unspecified), "Centro histórico de Salvador com arquitetura colonial preservada.", 5, "Centro Histórico", "Pelourinho", true },
                    { 5, "Corumbá", new DateTime(2024, 1, 4, 8, 0, 0, 0, DateTimeKind.Unspecified), "Maior planície alagável do mundo com biodiversidade única.", 12, "Região Centro-Oeste", "Pantanal", true },
                    { 6, "Foz do Iguaçu", new DateTime(2024, 1, 5, 7, 0, 0, 0, DateTimeKind.Unspecified), "Conjunto de quedas d'água espetaculares na fronteira com Argentina.", 16, "Parque Nacional do Iguaçu", "Cataratas do Iguaçu", true },
                    { 7, "Manaus", new DateTime(2024, 1, 6, 14, 0, 0, 0, DateTimeKind.Unspecified), "Casa de ópera histórica no coração da Amazônia.", 4, "Centro de Manaus", "Teatro Amazonas", true },
                    { 8, "Barreirinhas", new DateTime(2024, 1, 7, 12, 0, 0, 0, DateTimeKind.Unspecified), "Parque nacional com dunas de areia branca e lagoas cristalinas.", 10, "Parque Nacional dos Lençóis Maranhenses", "Lençóis Maranhenses", true },
                    { 9, "Ouro Preto", new DateTime(2024, 1, 8, 15, 0, 0, 0, DateTimeKind.Unspecified), "Cidade colonial com arquitetura barroca e história da mineração.", 13, "Centro da cidade", "Centro Histórico de Ouro Preto", true },
                    { 10, "Jericoacoara", new DateTime(2024, 1, 9, 16, 0, 0, 0, DateTimeKind.Unspecified), "Praia paradisíaca com dunas, lagoas e pôr do sol inesquecível.", 6, "Parque Nacional de Jericoacoara", "Jericoacoara", true },
                    { 11, "Fernando de Noronha", new DateTime(2024, 1, 10, 13, 0, 0, 0, DateTimeKind.Unspecified), "Arquipélago vulcânico com praias paradisíacas e vida marinha rica.", 17, "Arquipélago oceânico", "Ilha de Fernando de Noronha", true },
                    { 12, "Cambará do Sul", new DateTime(2024, 1, 11, 11, 0, 0, 0, DateTimeKind.Unspecified), "Cânions espetaculares com paisagens de tirar o fôlego.", 21, "Parque Nacional dos Aparados da Serra", "Aparados da Serra", true },
                    { 13, "Brasília", new DateTime(2024, 1, 12, 10, 0, 0, 0, DateTimeKind.Unspecified), "Capital federal com arquitetura modernista única no mundo.", 7, "Plano Piloto", "Brasília", true },
                    { 14, "Bonito", new DateTime(2024, 1, 13, 9, 30, 0, 0, DateTimeKind.Unspecified), "Destino de ecoturismo com rios cristalinos e cavernas impressionantes.", 12, "Região da Serra da Bodoquena", "Bonito", true },
                    { 15, "Balneário Camboriú", new DateTime(2024, 1, 14, 17, 0, 0, 0, DateTimeKind.Unspecified), "Praia urbana moderna com arranha-céus e vida noturna agitada.", 24, "Orla marítima", "Balneário Camboriú", true }
                });

            migrationBuilder.CreateIndex(
                name: "IX_PONTOS_TURISTICOS_EstadoId",
                table: "PONTOS_TURISTICOS",
                column: "EstadoId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "PONTOS_TURISTICOS");

            migrationBuilder.DropTable(
                name: "ESTADOS");
        }
    }
}
