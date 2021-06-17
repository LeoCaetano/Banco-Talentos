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
using AutoMapper;

namespace BancoTalentos.Mvc.Controllers
{
    public class ProfissaoController : Controller
    {
        private readonly IProfissaoRepository _repositoryProfissao;

        private readonly IMapper _mapper;

        public ProfissaoController(IProfissaoRepository repository, IMapper mapper)
        {
            _repositoryProfissao = repository;
            _mapper = mapper;
        }
        public IActionResult Consulta(){
            List<Profissao> profissoesBD = _repositoryProfissao.RetornaTodos();
            
            List<ProfissaoVM> profissoes = _mapper.Map<List<ProfissaoVM>>(profissoesBD);
            
            return View(profissoes);
            
        }

        public IActionResult Cadastro(){

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(ProfissaoVM profissaoVM)
        {

            Profissao profissao = _mapper.Map<Profissao>(profissaoVM);

            _repositoryProfissao.Salvar(profissao);
            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {   
            Profissao profissao = _repositoryProfissao.ObterPorId(id);

            ProfissaoVM profissaoVM = _mapper.Map<ProfissaoVM>(profissao);

            return View("Cadastro", profissaoVM);
        }

        public IActionResult Deletar(int id)
        {   
            _repositoryProfissao.Deletar(id);
            return RedirectToAction("Consulta");
        }
        
    }
}