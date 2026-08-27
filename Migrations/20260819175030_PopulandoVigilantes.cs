using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoVigilantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AlterColumn<string>(
                name: "UrlImagemPerfil",
                table: "Vigilante",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<int>(
                name: "Idade",
                table: "Vigilante",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<string>(
                name: "RefreshToken",
                table: "Vigilante",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            migrationBuilder.AddColumn<DateTime>(
                name: "RefreshTokenExpiryTime",
                table: "Vigilante",
                type: "datetime(6)",
                nullable: true);

            migrationBuilder.AddColumn<string>(
                name: "UrlImagemPerfil",
                table: "Empresa",
                type: "varchar(200)",
                maxLength: 200,
                nullable: true)
                .Annotation("MySql:CharSet", "utf8mb4");

            const string senha = "8Uq+k5D9D/rRBoFqyqAcCQ==;qtUuIC65Pn3/8rJVttX51H1uHwhKRkurmLWXsCDiHlQ="; // senha em texto puro: Vigily@123

            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Marcos Silva','11122233344','marcos.silva@vigily.com','{senha}','11987654321','São Paulo',34,'São Paulo')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Ana Souza','22233344455','ana.souza@vigily.com','{senha}','21987654321','Rio de Janeiro',29,'Rio de Janeiro')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Carlos Pereira','33344455566','carlos.pereira@vigily.com','{senha}','31987654321','Belo Horizonte',41,'Minas Gerais')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Juliana Costa','44455566677','juliana.costa@vigily.com','{senha}','41987654321','Curitiba',27,'Paraná')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Roberto Lima','55566677788','roberto.lima@vigily.com','{senha}','51987654321','Porto Alegre',38,'Rio Grande do Sul')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Patricia Alves','66677788899','patricia.alves@vigily.com','{senha}','61987654321','Brasília',33,'Distrito Federal')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Fernando Rocha','77788899900','fernando.rocha@vigily.com','{senha}','71987654321','Salvador',45,'Bahia')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Camila Ferreira','88899900011','camila.ferreira@vigily.com','{senha}','81987654321','Recife',30,'Pernambuco')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Rodrigo Martins','99900011122','rodrigo.martins@vigily.com','{senha}','85987654321','Fortaleza',36,'Ceará')");
            migrationBuilder.Sql($"Insert into Vigilante(Nome,Cpf,Email,Senha,Telefone,Cidade,Idade,Estado) values('Beatriz Santos','10011122233','beatriz.santos@vigily.com','{senha}','91987654321','Belém',25,'Pará')");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.Sql("DELETE FROM Vigilante WHERE Cpf IN ('11122233344','22233344455','33344455566','44455566677','55566677788','66677788899','77788899900','88899900011','99900011122','10011122233')");

            migrationBuilder.DropColumn(
                name: "Idade",
                table: "Vigilante");

            migrationBuilder.DropColumn(
                name: "RefreshToken",
                table: "Vigilante");

            migrationBuilder.DropColumn(
                name: "RefreshTokenExpiryTime",
                table: "Vigilante");

            migrationBuilder.DropColumn(
                name: "UrlImagemPerfil",
                table: "Empresa");

            migrationBuilder.UpdateData(
                table: "Vigilante",
                keyColumn: "UrlImagemPerfil",
                keyValue: null,
                column: "UrlImagemPerfil",
                value: "");

            migrationBuilder.AlterColumn<string>(
                name: "UrlImagemPerfil",
                table: "Vigilante",
                type: "varchar(200)",
                maxLength: 200,
                nullable: false,
                oldClrType: typeof(string),
                oldType: "varchar(200)",
                oldMaxLength: 200,
                oldNullable: true)
                .Annotation("MySql:CharSet", "utf8mb4")
                .OldAnnotation("MySql:CharSet", "utf8mb4");
        }
    }
}
