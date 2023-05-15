using AutoMapper;
using SistemaNoticias.API.ViewModels;
using SistemaNoticias.Domain.Entities;

namespace SistemaNoticias.API.Configuration
{
    public class AutomapperConfig : Profile
    {
        public AutomapperConfig()
        {
            CreateMap<Noticia, NoticiaViewModel>().ReverseMap();
            CreateMap<Classificacao, ClassificacaoViewModel>().ReverseMap();
        }
    }
}

