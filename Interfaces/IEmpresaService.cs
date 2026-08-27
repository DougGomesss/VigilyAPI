using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Interfaces
{
    public interface IEmpresaService
    {
        public Task<Empresa> LoginAsync(string cnpj, string senhaDigitada);
        public Task<Empresa> AtualizarEmpresaAsync(string cnpj, Empresa empresa);
        public Task<IEnumerable<Empresa>> GetEmpresasAsync();
        public Task<Empresa> GetEmpresaPorCNPJAsync(string cnpj);
        public Task<Empresa> PostAsync(EmpresaDTO dto);
    }
}
