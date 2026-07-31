using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class NovaMIgration : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder
                .AlterColumn<string>(
                    name: "UrlImagemPerfil",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "varchar(200)",
                    oldMaxLength: 200
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Telefone",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Senha",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Nome",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "varchar(80)",
                    oldMaxLength: 80
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Estado",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Email",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Cidade",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Telefone",
                    table: "Empresa",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Senha",
                    table: "Empresa",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Nome",
                    table: "Empresa",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "varchar(80)",
                    oldMaxLength: 80
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Email",
                    table: "Empresa",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "longtext"
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder
                .AlterColumn<string>(
                    name: "Cnpj",
                    table: "Empresa",
                    type: "longtext",
                    nullable: true,
                    oldClrType: typeof(string),
                    oldType: "varchar(20)",
                    oldMaxLength: 20
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
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
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Telefone",
                keyValue: null,
                column: "Telefone",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Telefone",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Senha",
                keyValue: null,
                column: "Senha",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Senha",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Nome",
                keyValue: null,
                column: "Nome",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Nome",
                    table: "Vigilante",
                    type: "varchar(80)",
                    maxLength: 80,
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Estado",
                keyValue: null,
                column: "Estado",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Estado",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Email",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "Cidade",
                keyValue: null,
                column: "Cidade",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Cidade",
                    table: "Vigilante",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Telefone",
                keyValue: null,
                column: "Telefone",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Telefone",
                    table: "Empresa",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Senha",
                keyValue: null,
                column: "Senha",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Senha",
                    table: "Empresa",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Nome",
                keyValue: null,
                column: "Nome",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Nome",
                    table: "Empresa",
                    type: "varchar(80)",
                    maxLength: 80,
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Email",
                keyValue: null,
                column: "Email",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Email",
                    table: "Empresa",
                    type: "longtext",
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.UpdateData(
                table: "Empresa",
                keyColumn: "Cnpj",
                keyValue: null,
                column: "Cnpj",
                value: ""
            );

            migrationBuilder
                .AlterColumn<string>(
                    name: "Cnpj",
                    table: "Empresa",
                    type: "varchar(20)",
                    maxLength: 20,
                    nullable: false,
                    oldClrType: typeof(string),
                    oldType: "longtext",
                    oldNullable: true
                )
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
