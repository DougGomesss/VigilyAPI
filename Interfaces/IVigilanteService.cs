using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Interfaces
{
    public interface IVigilanteService
    {
        public Task<Vigilante> LoginAsync(string cpf, string senhaDigitada);
        public Task<Vigilante> PutVigilanteAsync(string cpf, Vigilante vigilante);
        public Task<List<Vigilante>> GetVigilantesAsync();
        public Task<Vigilante> GetVigilanteByIDAsync(int id);
        public Task<List<Vigilante>> GetVigilantePorNomeAsync(string nome);
        public Task<Vigilante> PostVigilanteAsync(VigilanteDTO vigilante, int id = 0);
    }
}
