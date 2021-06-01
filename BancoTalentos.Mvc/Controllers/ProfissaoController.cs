using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancoTalentos.Mvc.Models;
using BancoTalentos.Dados;
using BancoTalentos.Modelos.Models;

namespace BancoTalentos.Mvc.Controllers
{
    public class ProfissaoController : Controller
    {
        private readonly AplicacaoContexto _contexto;
        public ProfissaoController(AplicacaoContexto contexto)
        {
            _contexto = contexto;
        }
        public IActionResult Consulta(){
            var profissoes = _contexto.ProfissaoDbSet.ToList();
            return View(profissoes);
        }

        public IActionResult Cadastro(){

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Profissao profissao)
        {

            if(profissao.IdProfissao > 0){
                Profissao prof = _contexto.ProfissaoDbSet.First(x => x.IdProfissao == profissao.IdProfissao);
                prof.Nome = profissao.Nome;
                prof.Ativo = profissao.Ativo;
            }else
                _contexto.ProfissaoDbSet.Add(profissao);
            
            await _contexto.SaveChangesAsync();
            
            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {
            var profissao = _contexto.ProfissaoDbSet.First(c => c.IdProfissao == id);
            
            return View("Cadastro", profissao);
        }

        public async Task<IActionResult> Deletar(int id)
        {
            var profissao = _contexto.ProfissaoDbSet.First(c => c.IdProfissao == id);
            _contexto.ProfissaoDbSet.Remove(profissao);
            await _contexto.SaveChangesAsync();
            
            return RedirectToAction("Consulta");
        }
        
    }
}