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
using BancoTalentos.Dados.Repositorios;
using BancoTalentos.Modelos.Interfaces;

namespace BancoTalentos.Mvc.Controllers
{
    public class ProfissaoController : Controller
    {
        private readonly IRepositoryProfissao _repositoryProfissao;
        public ProfissaoController(IRepositoryProfissao repository)
        {
            _repositoryProfissao = repository;
        }
        public async Task<IActionResult> Consulta(){
            var profissoes = await _repositoryProfissao.RetornaTodosAsync();
            return View(profissoes);
        }

        public IActionResult Cadastro(){

            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Salvar(Profissao profissao)
        {
            await _repositoryProfissao.SalvarAsync(profissao);
            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {   
            Profissao profissao = _repositoryProfissao.ConsultaPorIdAsync(id);

            return View("Cadastro", profissao);
        }

        public IActionResult Deletar(int id)
        {   
            _repositoryProfissao.Deletar(id);
            return RedirectToAction("Consulta");
        }
        
    }
}