using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BancoTalentos.Modelos.Interfaces;
using BancoTalentos.Modelos.Models;

namespace BancoTalentos.Dados.Repositorios
{
    public class EmpresaRepository : IEmpresaRepository
    {
        private readonly AplicacaoContexto _contexto;

        public EmpresaRepository(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }

        public Empresa ObterPorId(int id)
        {
           return _contexto.EmpresaDbSet.FirstOrDefault(x => x.IdEmpresa == id);
        }

        public List<Empresa> RetornaTodos()
        {
            return _contexto.EmpresaDbSet.ToList();
        }

        public void Salvar(Empresa empresa)
        {
            if (empresa.IdEmpresa > 0)
            {
                Empresa emp = _contexto.EmpresaDbSet.First(x => x.IdEmpresa == empresa.IdEmpresa);
                emp.RazaoSocial = empresa.RazaoSocial;
                emp.Ativo = empresa.Ativo;
                emp.Telefone = empresa.Telefone;
                emp.CNPJ = empresa.CNPJ;
            }
            else
                _contexto.EmpresaDbSet.Add(empresa);

            _contexto.SaveChanges();
        }


        public bool Deletar(int id)
        {
            Empresa empresa = _contexto.EmpresaDbSet.First(x => x.IdEmpresa == id);

            _contexto.EmpresaDbSet.Remove(empresa);

            return _contexto.SaveChanges() > 0;
        }
    }
}
