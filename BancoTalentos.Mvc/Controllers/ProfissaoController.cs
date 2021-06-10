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
        public IActionResult Consulta(){
            var profissoes = _repositoryProfissao.RetornaTodos();
            return View(profissoes);
        }

        public IActionResult Cadastro(){

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Profissao profissao)
        {
            _repositoryProfissao.Salvar(profissao);
            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {   
            Profissao profissao = _repositoryProfissao.ObterPorId(id);

            return View("Cadastro", profissao);
        }

        public IActionResult Deletar(int id)
        {   
            _repositoryProfissao.Deletar(id);
            return RedirectToAction("Consulta");
        }
        
    }
}