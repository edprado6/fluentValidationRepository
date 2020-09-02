using AutoMapper;
using FluentValidation.Api.ViewModels;
using FluentValidation.Domain.Entities;

namespace FluentValidation.Api.Mappers
{

    public class AutoMapperConfig
    {
        public IMapper IMapper()
        {
            var config = new MapperConfiguration(cfg => {
                cfg.CreateMap<Usuario, UsuarioViewModel>();
                cfg.CreateMap<UsuarioViewModel, Usuario>();
            });

            return config.CreateMapper();
        }
    }
}