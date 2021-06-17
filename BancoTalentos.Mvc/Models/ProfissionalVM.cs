using System;

namespace BancoTalentos.Mvc.Models
{
    public class ProfissionalVM
    {
        public int ID { get; set; } 
        public string NomeCompleto {get;set;}
        public DateTime DataNascimento  { get; set; }
        public string Email  { get; set; }
        public string Telefone  { get; set; }
        public int IdProfissao { get; set; }
        public string Profissao { get; set; }
        public bool Ativo { get; set; }
        }
}