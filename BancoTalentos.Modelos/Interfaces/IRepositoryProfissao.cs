using BancoTalentos.Modelos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IRepositoryProfissao : IRepositorioBase<Profissao>
    {
        bool Deletar(int id);
    }
}