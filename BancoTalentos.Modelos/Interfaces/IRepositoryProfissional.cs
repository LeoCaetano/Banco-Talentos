using BancoTalentos.Modelos.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IRepositoryProfissional : IRepositorioBase<Profissional>
    {
        bool TrocarStatus(int id, bool novoStatus);
    }
}