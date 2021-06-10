using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System;

namespace BancoTalentos.Modelos.Models
{
    [Table("Profissional")]
    public class Profissional
    {
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

        [ForeignKey("IdProfissao")]
        public int IdProfissao { get; set; }
        public Profissao Profissao { get; set; }
        
        [ForeignKey("DataInclusao")]
        public DateTime DataInclusao { get; set; }

        [ForeignKey("Ativo")]
        public bool Ativo { get; set; }
    }
}