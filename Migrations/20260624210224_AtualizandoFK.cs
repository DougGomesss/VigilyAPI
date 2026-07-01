using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoFK : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "Id", table: "Vigilante", newName: "VigilanteId");

            migrationBuilder.RenameColumn(name: "Id", table: "Empresa", newName: "EmpresaId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.RenameColumn(name: "VigilanteId", table: "Vigilante", newName: "Id");

            migrationBuilder.RenameColumn(name: "EmpresaId", table: "Empresa", newName: "Id");
        }
    }
}
