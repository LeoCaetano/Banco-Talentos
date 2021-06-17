using BancoTalentos.Modelos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IProfissaoRepository : IBaseRepository<Profissao>
    {
        bool Deletar(int id);
    }
}