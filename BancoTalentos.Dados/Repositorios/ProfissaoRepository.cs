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
    public class ProfissaoRepository : IProfissaoRepository
    {
        private readonly AplicacaoContexto _contexto;

        public ProfissaoRepository(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }
        public void Salvar(Profissao profissao)
        {
            
            if(profissao.IdProfissao > 0){
                Profissao prof = _contexto.ProfissaoDbSet.First(x => x.IdProfissao == profissao.IdProfissao);
                prof.Nome = profissao.Nome;
                prof.Ativo = profissao.Ativo;
            }else
                _contexto.ProfissaoDbSet.Add(profissao);
            
            _contexto.SaveChanges();

        }

        public Profissao ObterPorId(int id)
        {
            return _contexto.ProfissaoDbSet.First(c => c.IdProfissao == id);
        }

        public List<Profissao> RetornaTodos()
        {
            return _contexto.ProfissaoDbSet.ToList();
        }

        public bool Deletar(int id)
        {
            Profissao profissao = _contexto.ProfissaoDbSet.First(x => x.IdProfissao == id);

            _contexto.ProfissaoDbSet.Remove(profissao);

            return _contexto.SaveChanges() > 0;
        }

    }
}