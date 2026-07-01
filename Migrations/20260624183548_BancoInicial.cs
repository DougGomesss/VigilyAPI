using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class BancoInicial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterDatabase().Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "Empresa",
                    columns: table => new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        Nome = table
                            .Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Cnpj = table
                            .Column<string>(type: "varchar(20)", maxLength: 20, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Email = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Telefone = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Empresa", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "Vigilante",
                    columns: table => new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        Nome = table
                            .Column<string>(type: "varchar(80)", maxLength: 80, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Email = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Telefone = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Cidade = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        Estado = table
                            .Column<string>(type: "longtext", nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                        UrlImagemPerfil = table
                            .Column<string>(type: "varchar(200)", maxLength: 200, nullable: false)
                            .Annotation("MySql:CharSet", "utf8mb4"),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_Vigilante", x => x.Id);
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .CreateTable(
                    name: "ListaSolicitacoes",
                    columns: table => new
                    {
                        Id = table
                            .Column<int>(type: "int", nullable: false)
                            .Annotation(
                                "MySql:ValueGenerationStrategy",
                                MySqlValueGenerationStrategy.IdentityColumn
                            ),
                        EmpresaId = table.Column<int>(type: "int", nullable: true),
                        VigilanteId = table.Column<int>(type: "int", nullable: true),
                        Status = table.Column<int>(type: "int", nullable: false),
                    },
                    constraints: table =>
                    {
                        table.PrimaryKey("PK_ListaSolicitacoes", x => x.Id);
                        table.ForeignKey(
                            name: "FK_ListaSolicitacoes_Empresa_EmpresaId",
                            column: x => x.EmpresaId,
                            principalTable: "Empresa",
                            principalColumn: "Id"
                        );
                        table.ForeignKey(
                            name: "FK_ListaSolicitacoes_Vigilante_VigilanteId",
                            column: x => x.VigilanteId,
                            principalTable: "Vigilante",
                            principalColumn: "Id"
                        );
                    }
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.CreateIndex(
                name: "IX_ListaSolicitacoes_EmpresaId",
                table: "ListaSolicitacoes",
                column: "EmpresaId"
            );

            migrationBuilder.CreateIndex(
                name: "IX_ListaSolicitacoes_VigilanteId",
                table: "ListaSolicitacoes",
                column: "VigilanteId"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(name: "ListaSolicitacoes");

            migrationBuilder.DropTable(name: "Empresa");

            migrationBuilder.DropTable(name: "Vigilante");
        }
    }
}
