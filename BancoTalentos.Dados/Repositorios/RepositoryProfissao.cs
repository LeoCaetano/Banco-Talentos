using System.Collections.Generic;
using System.Threading.Tasks;
using BancoTalentos.Modelos.Interfaces;
using BancoTalentos.Modelos.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Diagnostics;
using System.Linq;


namespace BancoTalentos.Dados.Repositorios
{
    public class RepositoryProfissao : IRepositoryProfissao
    {
        private readonly AplicacaoContexto _contexto;

        public RepositoryProfissao(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }
        public async Task<bool> SalvarAsync(Profissao profissao)
        {
            
            if(profissao.IdProfissao > 0){
                Profissao prof = await _contexto.ProfissaoDbSet.FirstAsync(x => x.IdProfissao == profissao.IdProfissao);
                prof.Nome = profissao.Nome;
                prof.Ativo = profissao.Ativo;
            }else
                _contexto.ProfissaoDbSet.Add(profissao);
            
            return await _contexto.SaveChangesAsync() > 0;
        }

        public Profissao ConsultaPorIdAsync(int id)
        {
            return _contexto.ProfissaoDbSet.First(c => c.IdProfissao == id);
        }

        public Task<List<Profissao>> RetornaTodosAsync()
        {
            return _contexto.ProfissaoDbSet.ToListAsync();
        }

        public bool Deletar(int id)
        {
            Profissao profissao = _contexto.ProfissaoDbSet.First(x => x.IdProfissao == id);

            _contexto.Remove(profissao);

            return _contexto.SaveChanges() > 0;
        }
    }
}