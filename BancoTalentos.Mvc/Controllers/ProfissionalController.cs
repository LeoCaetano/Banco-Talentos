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
    public class ProfissionalController : Controller
    {
        private readonly IRepositoryProfissional _repositoryProfissional;
        private readonly IRepositoryProfissao _repositoryProfissao;
        public ProfissionalController(IRepositoryProfissional repositoryProfissional, IRepositoryProfissao repositoryProfissao)
        {
            _repositoryProfissional = repositoryProfissional;
            _repositoryProfissao = repositoryProfissao;
        }
        public IActionResult Consulta(){
            var profissoes = _repositoryProfissional.RetornaTodos();
            return View(profissoes);
        }

        public IActionResult Cadastro(){
            ViewBag.profissoes = _repositoryProfissao.RetornaTodos();

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(Profissional profissional)
        {
            _repositoryProfissional.Salvar(profissional);
            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {   
            Profissional profissional = _repositoryProfissional.ObterPorId(id);

            return View("Cadastro", profissional);
        }

        public IActionResult Inativar(int id)
        {   
            _repositoryProfissional.TrocarStatus(id, false);
            return RedirectToAction("Consulta");
        }
        
    }
}