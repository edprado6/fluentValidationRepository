using AutoMapper;
using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using FluentValidation.WebApi.Mappers;
using FluentValidation.WebApi.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FluentValidation.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioController : ApiController
    {       

        public IUsuarioService _usuarioService { private get; set; }

        public IMapper _iMapper;

        public UsuarioController()
        {
            _iMapper = new AutoMapperConfig().IMapper();
        }
        /// <summary>
        /// Retorna uma lista de usuarios.
        /// </summary>
        /// <returns></returns>
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
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
       /// Insere um novo registro.
       /// </summary>
       /// <param name="usuarioViewModel"></param>
       /// <returns></returns>
        //public UsuarioViewModel Post([FromBody]UsuarioViewModel usuarioViewModel)
        //{
        //    var usuario = _iMapper.Map<Usuario>(usuarioViewModel);
        //    usuario = _usuarioService.Insert(usuario);

        //    usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
        //    return usuarioViewModel;
        //}

        [HttpPost]
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
        /// Atualiza um registro.
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioViewModel"></param>
        /// <returns></returns>
        public UsuarioViewModel Put(int id, [FromBody]UsuarioViewModel usuarioViewModel)
        {
            return usuarioViewModel;
        }

        /// <summary>
        /// Remove um registro.
        /// </summary>
        /// <param name="id"></param>
        public void Delete(int id)
        {

        }
    }
}
