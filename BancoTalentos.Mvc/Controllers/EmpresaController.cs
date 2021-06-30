using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using BancoTalentos.Dados;
using BancoTalentos.Modelos.Models;
using BancoTalentos.Modelos.Interfaces;
using AutoMapper;
using BancoTalentos.Mvc.Models;

namespace BancoTalentos.Mvc.Controllers
{
    public class EmpresaController : Controller
    {
        private readonly IEmpresaRepository _repositoryEmpresa;

        private readonly IMapper _mapper;

        public EmpresaController(IEmpresaRepository repository, IMapper mapper)
        {
            _repositoryEmpresa = repository;
            _mapper = mapper;
        }
        public IActionResult Consulta()
        {
            List<Empresa> empresaBD = _repositoryEmpresa.RetornaTodos();

            List<EmpresaVM> empresas = _mapper.Map<List<EmpresaVM>>(empresaBD);

            return View(empresas);

        }

        public IActionResult Cadastro()
        {

            return View();
        }

        [HttpPost]
        public IActionResult Salvar(EmpresaVM EmpresaVM)
        {

            Empresa empresa = _mapper.Map<Empresa>(EmpresaVM);

            _repositoryEmpresa.Salvar(empresa);
            return RedirectToAction("Consulta");
        }

        [HttpGet]
        public IActionResult Editar(int id)
        {
            Empresa empresa = _repositoryEmpresa.ObterPorId(id);

            EmpresaVM empresaVM = _mapper.Map<EmpresaVM>(empresa);

            return View("Cadastro", empresaVM);
        }

        public IActionResult Deletar(int id)
        {
            _repositoryEmpresa.Deletar(id);
            return RedirectToAction("Consulta");
        }
    }
}
