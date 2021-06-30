using BancoTalentos.Modelos.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IEmpresaRepository : IBaseRepository<Empresa>
    {
        bool Deletar(int id);
    }
}
