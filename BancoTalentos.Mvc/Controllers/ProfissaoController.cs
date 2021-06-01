using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using BancoTalentos.Mvc.Models;
using BancoTalentos.Dados;

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
        
    }
}