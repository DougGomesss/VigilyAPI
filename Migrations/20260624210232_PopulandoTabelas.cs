using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoTabelas : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                "Insert into Empresa(Nome,Cnpj,Email,Telefone) values('Douglas LTDA','8795498758','douglasgomesoliveira00@gmail.com','11980491930')"
            );
            mb.Sql(
                "Insert into Empresa(Nome,Cnpj,Email,Telefone) values('Jose LTDA','985648795','joseLTDA@gmail.com','11980491930')"
            );
            mb.Sql(
                "Insert into Empresa(Nome,Cnpj,Email,Telefone) values('Ronaldo LTDA','2226548795','ronaldoLTDA@gmail.com','11980491930')"
            );
            mb.Sql(
                "Insert into Vigilante(Nome,Email,Telefone,Cidade,Estado,UrlImagemPerfil) values('Douglas','douglasgomesoliveira00@gmail.com','11980491930','São Paulo','São Paulo','imagem.jpg')"
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql("DELETE FROM Empresa WHERE Cnpj IN ('8795498758','985648795','2226548795')");
            mb.Sql("DELETE FROM Vigilante WHERE Email IN ('douglasgomesoliveira00@gmail.com')");
        }
    }
}
