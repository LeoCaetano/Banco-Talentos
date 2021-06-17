using AutoMapper;
using BancoTalentos.Mvc.Models;
using BancoTalentos.Modelos.Models;

namespace BancoTalentos.Mvc.Services
{
    public class MappingProfile : Profile
    {
        public MappingProfile() {
          CreateMap<Profissao, ProfissaoVM>()
            .ForMember(dest => dest.Id, o => o.MapFrom(src => src.IdProfissao));

          CreateMap<ProfissaoVM, Profissao>()
            .ForMember(dest => dest.IdProfissao, o => o.MapFrom(src => src.Id));

          CreateMap<Profissional, ProfissionalVM>()
            .ForMember(dest => dest.ID, o => o.MapFrom(src => src.IdProfissional))
            .ForMember(dest => dest.Profissao, o => o.MapFrom(src => src.Profissao.Nome));

          CreateMap<ProfissionalVM, Profissional>()
            .ForMember(dest => dest.IdProfissional, o => o.MapFrom(src => src.ID));
     }
        
    }
}