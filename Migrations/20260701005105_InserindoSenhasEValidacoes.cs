using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class InserindoSenhasEValidacoes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .AddColumn<string>(
                    name: "Cpf",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AddColumn<string>(
                    name: "Senha",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false
                )
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AddColumn<string>(
                    name: "Senha",
                    table: "Empresa",
                    type: "longtext",
                    nullable: false
                )
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Cpf", table: "Vigilante");

            migrationBuilder.DropColumn(name: "Senha", table: "Vigilante");

            migrationBuilder.DropColumn(name: "Senha", table: "Empresa");
        }
    }
}
