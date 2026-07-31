using VigilyAPI.Interfaces;

namespace VigilyAPI.Services
{
    public class MeuServico : IMeuService
    {
        public string Saldacao(string nome)
        {
            return $"Bem Vindo {nome} | {DateTime.UtcNow}";
        }
    }
}
