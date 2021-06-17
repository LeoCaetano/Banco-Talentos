using BancoTalentos.Dados.Repositorios;
using BancoTalentos.Modelos.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace BancoTalentos.Mvc.Extensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProfissaoRepository, ProfissaoRepository>();
            services.AddScoped<IProfissionalRepository, ProfissionalRepository>();

            return services;
        }
    }
}