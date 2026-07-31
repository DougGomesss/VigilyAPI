using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace VigilyAPI.Migrations
{
    /// <inheritdoc />
    public partial class AtualizandoIdadeVigilantes : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder mb)
        {
            mb.Sql(
                @"
                UPDATE `Vigilante` SET `Idade` = 24 WHERE `Cpf` = '11122233344';
                UPDATE `Vigilante` SET `Idade` = 40 WHERE `Cpf` = '22233344455';
                UPDATE `Vigilante` SET `Idade` = 65 WHERE `Cpf` = '33344455566';
                UPDATE `Vigilante` SET `Idade` = 33 WHERE `Cpf` = '44455566677';
                UPDATE `Vigilante` SET `Idade` = 22 WHERE `Cpf` = '55566677788';
                UPDATE `Vigilante` SET `Idade` = 28 WHERE `Cpf` = '66677788899';
                UPDATE `Vigilante` SET `Idade` = 29 WHERE `Cpf` = '77788899900';
                UPDATE `Vigilante` SET `Idade` = 33 WHERE `Cpf` = '88899900011';
                UPDATE `Vigilante` SET `Idade` = 43 WHERE `Cpf` = '99900011122';
                UPDATE `Vigilante` SET `Idade` = 41 WHERE `Cpf` = '00011122233';
            "
            );
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder mb)
        {
            mb.Sql(
                @"
                UPDATE `Vigilante` SET `Idade` = 0 WHERE `Cpf` IN (
                    '11122233344', '22233344455', '33344455566', '44455566677', '55566677788',
                    '66677788899', '77788899900', '88899900011', '99900011122', '00011122233'
                );
            "
            );
        }
    }
}
