using System.Collections.Generic;

namespace BancoTalentos.Modelos.Interfaces
{
    public interface IBaseRepository<TEntidade>
    
    {
        TEntidade ObterPorId(int id);
        List<TEntidade> RetornaTodos();
        void Salvar(TEntidade entity);
    
    }
}