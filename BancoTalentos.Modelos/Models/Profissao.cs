using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BancoTalentos.Modelos.Models
{
    [Table("Profissao")]
    public class Profissao
    {
        
        [KeyAttribute]
        public int IdProfissao { get; set; }

        [Column("Nome")]
        public string Nome { get; set; }

        [Column("Ativo")]
        public bool Ativo { get; set; }
    }
}