using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class ReviewDeModelos : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .AlterColumn<string>(
                    name: "UrlImagemPerfil",
                    table: "Vigilante",
                    type: "varchar(200)",
                    maxLength: 200,
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "varchar(200)",
                    oldMaxLength: 200
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Vigilante",
                type: "int",
                nullable: false,
                defaultValue: 0
            );

            migrationBuilder
                .AddColumn<string>(
                    name: "UrlImagemPerfil",
                    table: "Empresa",
                    type: "varchar(200)",
                    maxLength: 200,
                    nullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(name: "Idade", table: "Vigilante");

            migrationBuilder.DropColumn(name: "UrlImagemPerfil", table: "Empresa");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "UrlImagemPerfil",
                keyValue: null,
                column: "UrlImagemPerfil",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "UrlImagemPerfil",
                    table: "Vigilante",
                    type: "varchar(200)",
                    maxLength: 200,
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "varchar(200)",
                    oldMaxLength: 200,
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
