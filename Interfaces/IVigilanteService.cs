using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Interfaces
{
    public interface IVigilanteService
    {
        public Task<Vigilante> Login(string cpf, string senhaDigitada);

        public Vigilante PutVigilante(string cpf, Vigilante vigilante);

        public List<Vigilante> GetVigilantes();

        public Vigilante GetVigilanteByID(int id);

        public Vigilante PostVigilante(VigilanteDTO vigilante, int id = 0);
    }
}
