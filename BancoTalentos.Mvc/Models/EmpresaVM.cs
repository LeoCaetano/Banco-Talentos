using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoTalentos.Mvc.Models
{
    public class EmpresaVM
    {
        public int ID { get; set; }

        public string RazaoSocial { get; set; }

        public string Telefone { get; set; }

        public string CNPJ { get; set; }

        public bool Ativo { get; set; }
    }
}
