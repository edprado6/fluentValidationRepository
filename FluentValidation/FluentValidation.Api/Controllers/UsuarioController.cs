using AutoMapper;
using FluentValidation.Api.Mappers;
using FluentValidation.Api.ViewModels;
using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FluentValidation.Api.Controllers
{
    public class UsuarioController : ApiController
    {

        public IUsuarioService _usuarioService { private get; set; }

        public IMapper _iMapper;

        public UsuarioController()
        {
            _iMapper = new AutoMapperConfig().IMapper();
        }

        /// <summary>
        /// Retorna um unico usuario.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public UsuarioViewModel Get(long id)
        {
            var usuario = _usuarioService.GetById(id);
            var usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
            return usuarioViewModel;
        }

        /// <summary>
        /// Insere um novo registro na tabela de usuarios
        /// </summary>
        /// <param name="usuarioViewModel"></param>
        /// <returns></returns>
        public HttpResponseMessage Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                var usuario = _iMapper.Map<Usuario>(usuarioViewModel);
                usuario = _usuarioService.Insert(usuario);

                usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
                return Request.CreateResponse(HttpStatusCode.OK, usuarioViewModel);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

       /// <summary>
       /// Atualiza um registro na tabela de usuarios
       /// </summary>
       /// <param name="id"></param>
       /// <param name="usuarioViewModel"></param>
        public void Put(int id, [FromBody]UsuarioViewModel usuarioViewModel)
        {

        }
    }
}