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
    public class ProfissionalController : Controller
    {
        private readonly IProfissionalRepository _repositoryProfissional;
        private readonly IProfissaoRepository _repositoryProfissao;
        private readonly IMapper _mapper;

        public ProfissionalController(IProfissionalRepository repositoryProfissional
            , IProfissaoRepository repositoryProfissao
            , IMapper mapper)
        {
            _repositoryProfissional = repositoryProfissional;
            _repositoryProfissao = repositoryProfissao;
            _mapper = mapper;
        }
        public IActionResult Consulta(){
            List<Profissional> profissionalBD = _repositoryProfissional.RetornaTodos();

            List<ProfissionalVM> profissionais = _mapper.Map<List<ProfissionalVM>>(profissionalBD);

            return View(profissionais);
        }

        public IActionResult Cadastro(){

            List<Profissao> profissoesBD = _repositoryProfissao.RetornaTodos();
            
            List<ProfissaoVM> profissoes = _mapper.Map<List<ProfissaoVM>>(profissoesBD);
            ViewBag.Profissoes = profissoes;
            return View();
        }

        [HttpPost]
        public IActionResult Salvar(ProfissionalVM profissionalVM)
        {

            Profissional profissional = _mapper.Map<Profissional>(profissionalVM);
            _repositoryProfissional.Salvar(profissional);

            return RedirectToAction("Consulta");
        }

        [HttpGet]
         public IActionResult Editar(int id)
        {   
            Profissional profissional = _repositoryProfissional.ObterPorId(id);
            ProfissionalVM profissionalVM = _mapper.Map<ProfissionalVM>(profissional);

            List<Profissao> profissoesBD = _repositoryProfissao.RetornaTodos();

            List<ProfissaoVM> profissoes = _mapper.Map<List<ProfissaoVM>>(profissoesBD);
            ViewBag.Profissoes = profissoes;

            return View("Cadastro", profissionalVM);
        }

        public IActionResult Inativar(int id)
        {   
            _repositoryProfissional.TrocarStatus(id, false);
            return RedirectToAction("Consulta");
        }
        
    }
}