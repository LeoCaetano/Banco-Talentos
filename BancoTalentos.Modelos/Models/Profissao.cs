using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace BancoTalentos.Modelos.Models
{
    [Table("Profissao")]
    public class Profissao
    {
        
        [Key]
        public int IdProfissao { get; set; }

        public string Nome { get; set; }

        public bool Ativo { get; set; }
    }
}