using BancoTalentos.Modelos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IRepositoryProfissao
    {
        Task<List<Profissao>> RetornaTodosAsync();
        Profissao ConsultaPorIdAsync(int id);
        Task<bool> SalvarAsync(Profissao profissao);

        bool Deletar(int id);
    }
}