using BancoTalentos.Modelos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IProfissionalRepository : IBaseRepository<Profissional>
    {
        bool TrocarStatus(int id, bool novoStatus);
    }
}