using Microsoft.EntityFrameworkCore;
using BancoTalentos.Modelos.Models;

namespace BancoTalentos.Dados
{
    public class AplicacaoContexto : DbContext
    {
        public AplicacaoContexto(DbContextOptions<AplicacaoContexto> options) : base(options){}
        
        public DbSet<Profissao> ProfissaoDbSet{ get; set; }

        public DbSet<Profissional> ProfissionalDbSet{ get; set; }
        
    }
}