using AutoMapper;
using FluentValidation.Domain.Entities;
using FluentValidation.WebApi.ViewModels.Entities;

namespace FluentValidation.WebApi.Mappers
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


/*
    //var config = new MapperConfiguration(cfg =>
    //{
    //    cfg.CreateMap<Usuario, UsuarioViewModel>();
    //});
    //IMapper iMapper = config.CreateMapper();
    //var usuarioViewModel = iMapper.Map<Usuario, UsuarioViewModel>(usuario);
    //return usuarioViewModel; 
 */
