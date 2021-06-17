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
    public class ProfissionalRepository : IProfissionalRepository
    {
        private readonly AplicacaoContexto _contexto;

        public ProfissionalRepository(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }
       
        public List<Profissional> RetornaTodos()
        {
            return _contexto.ProfissionalDbSet
                .Include(x => x.Profissao).ToList();
        }

        public void Salvar(Profissional profissional)
        {
            if(profissional.IdProfissional > 0){
                Profissional prof = _contexto.ProfissionalDbSet.First(x => x.IdProfissional == profissional.IdProfissional);
                
                prof.NomeCompleto = profissional.NomeCompleto;
                prof.Ativo = profissional.Ativo;
                prof.IdProfissao = profissional.IdProfissao;
                prof.Email = profissional.Email;
                prof.Telefone = profissional.Telefone;
                prof.DataNascimento = profissional.DataNascimento;
            }else
                _contexto.ProfissionalDbSet.Add(profissional);
            
            _contexto.SaveChanges();
        }

        public Profissional ObterPorId(int id)
        {
            return _contexto.ProfissionalDbSet.First(x => x.IdProfissional == id);
        }

        public bool TrocarStatus(int id, bool novoStatus)
        {
            Profissional prof = _contexto.ProfissionalDbSet.First(x => x.IdProfissional == id);
            prof.Ativo = novoStatus;

            return _contexto.SaveChanges() > 0;

        }
    }
}