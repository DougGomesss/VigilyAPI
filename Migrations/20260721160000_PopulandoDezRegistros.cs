using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class PopulandoDezRegistros : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                @"
                DELETE FROM `Empresa` WHERE `Cnpj` IN ('12345678000190', '98765432000121');
            "
            );

            mb.Sql(
                @"
                DELETE FROM `Vigilante` WHERE `Cpf` IN ('12345678901', '98765432100');
            "
            );

            mb.Sql(
                @"
                INSERT INTO `Empresa` (`Nome`, `Cnpj`, `Email`, `Telefone`, `Senha`)
                VALUES
                    ('Segurança Horizonte Ltda', '11222333000181', 'contato@horizonte.com.br', '11911112222', 'senha001'),
                    ('Vigia Total S.A.', '22333444000162', 'contato@vigiatotal.com.br', '11922223333', 'senha002'),
                    ('Proteção Norte Ltda', '33444555000143', 'contato@protecaonorte.com.br', '11933334444', 'senha003'),
                    ('Sentinela Serviços Ltda', '44555666000124', 'contato@sentinela.com.br', '11944445555', 'senha004'),
                    ('Guarda Vip S.A.', '55666777000105', 'contato@guardavip.com.br', '11955556666', 'senha005'),
                    ('Escudo Segurança Ltda', '66777888000186', 'contato@escudo.com.br', '11966667777', 'senha006'),
                    ('Vigilância Sul Ltda', '77888999000167', 'contato@vigilanciasul.com.br', '11977778888', 'senha007'),
                    ('Muralha Forte S.A.', '88999000000148', 'contato@muralhaforte.com.br', '11988889999', 'senha008'),
                    ('Fortaleza Segura Ltda', '99000111000129', 'contato@fortalezasegura.com.br', '11999990000', 'senha009'),
                    ('Bastião Proteção Ltda', '10111222000100', 'contato@bastiao.com.br', '11900001111', 'senha010');
            "
            );

            mb.Sql(
                @"
                INSERT INTO `Vigilante` (`Nome`, `Cpf`, `Email`, `Senha`, `Telefone`, `Cidade`, `Estado`, `UrlImagemPerfil`,`idade`)
                VALUES
                    ('Carlos Souza', '11122233344', 'carlos.souza@email.com', 'senha101', '11911112222', 'São Paulo', 'SP', 'https://exemplo.com/imagens/carlos.jpg','24'),
                    ('Fernanda Lima', '22233344455', 'fernanda.lima@email.com', 'senha102', '21922223333', 'Rio de Janeiro', 'RJ', 'https://exemplo.com/imagens/fernanda.jpg','40'),
                    ('Ricardo Alves', '33344455566', 'ricardo.alves@email.com', 'senha103', '31933334444', 'Belo Horizonte', 'MG', 'https://exemplo.com/imagens/ricardo.jpg','65'),
                    ('Juliana Costa', '44455566677', 'juliana.costa@email.com', 'senha104', '41944445555', 'Curitiba', 'PR', 'https://exemplo.com/imagens/juliana.jpg','33'),
                    ('Marcos Pereira', '55566677788', 'marcos.pereira@email.com', 'senha105', '51955556666', 'Porto Alegre', 'RS', 'https://exemplo.com/imagens/marcos.jpg','22'),
                    ('Patrícia Rocha', '66677788899', 'patricia.rocha@email.com', 'senha106', '61966667777', 'Brasília', 'DF', 'https://exemplo.com/imagens/patricia.jpg','28'),
                    ('André Martins', '77788899900', 'andre.martins@email.com', 'senha107', '71977778888', 'Salvador', 'BA', 'https://exemplo.com/imagens/andre.jpg','29'),
                    ('Camila Ferreira', '88899900011', 'camila.ferreira@email.com', 'senha108', '81988889999', 'Recife', 'PE', 'https://exemplo.com/imagens/camila.jpg','33'),
                    ('Bruno Cardoso', '99900011122', 'bruno.cardoso@email.com', 'senha109', '85999990000', 'Fortaleza', 'CE', 'https://exemplo.com/imagens/bruno.jpg','43'),
                    ('Larissa Nunes', '00011122233', 'larissa.nunes@email.com', 'senha110', '92900001111', 'Manaus', 'AM', 'https://exemplo.com/imagens/larissa.jpg','41');
            "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(
                @"
                DELETE FROM `Empresa` WHERE `Cnpj` IN (
                    '11222333000181', '22333444000162', '33444555000143', '44555666000124', '55666777000105',
                    '66777888000186', '77888999000167', '88999000000148', '99000111000129', '10111222000100'
                );
            "
            );

            mb.Sql(
                @"
                DELETE FROM `Vigilante` WHERE `Cpf` IN (
                    '11122233344', '22233344455', '33344455566', '44455566677', '55566677788',
                    '66677788899', '77788899900', '88899900011', '99900011122', '00011122233'
                );
            "
            );
        }
    }
}
