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

        [KeyAttribute]
        public int IdProfissional { get; set; }
        
        [Column("NomeCompleto")]
        public string  NomeCompleto { get; set; }
        
        [Column("DataNascimento")]
        public DateTime? DataNascimento { get; set; }    
        
        [Column("Email")]
        public string Email { get; set; }

        [Column("Telefone")]
        public string Telefone { get; set; }

        
        public int IdProfissao { get; set; }
        
        [ForeignKey("IdProfissao")]
        public Profissao Profissao { get; set; }
        
        [Column("DataInclusao")]
        public DateTime DataInclusao { get; set; }

        [ForeignKey("Ativo")]
        public bool Ativo { get; set; }
    }
}