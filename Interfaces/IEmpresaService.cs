using VigilyAPI.DTOs;
using VigilyAPI.Models;

namespace VigilyAPI.Interfaces
{
    public interface IEmpresaService
    {
        public Empresa AtualizarEmpresa(string cnpj, Empresa empresa);
        public IEnumerable<Empresa> GetEmpresas();
        public Empresa GetEmpresaPorID(int id);
        public Empresa Post(EmpresaDTO dto);
    }
}
