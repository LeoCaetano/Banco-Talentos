using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BancoTalentos.Modelos.Models
{
    [Table("Profissional")]
    public class Profissional
    {
        public Profissional()
        {
            DataInclusao = DateTime.Now;
        }

        [Key]
        public int IdProfissional { get; set; }
        
        public string  NomeCompleto { get; set; }
        
        public DateTime? DataNascimento { get; set; }    
        
        public string Email { get; set; }

        public string Telefone { get; set; }

        public int IdProfissao { get; set; }
        
        [ForeignKey("IdProfissao")]
        public Profissao Profissao { get; set; }
        
        public DateTime DataInclusao { get; set; }

        public bool Ativo { get; set; }
    }
}