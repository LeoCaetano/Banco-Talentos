using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BancoTalentos.Modelos.Models
{
    [Table("Empresa")]
    public class Empresa
    {
        [Key]
        public int IdEmpresa { get; set; }
        public string RazaoSocial { get; set; }
        public string CNPJ { get; set; }
        public string Telefone { get; set; }

        public bool Ativo { get; set; }

    }
}
