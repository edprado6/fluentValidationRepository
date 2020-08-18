using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using FluentValidation.WebApi.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FluentValidation.WebApi.Controllers
{
    /// <summary>
    /// 
    /// </summary>
    public class UsuarioController : ApiController
    {       

        public IUsuarioService _usuarioService { private get; set; }

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
        public Usuario Get(long id)
        {
            var usuarioViewModel = _usuarioService.GetById(id);

            return usuarioViewModel;
        }

       /// <summary>
       /// Insere um novo registro.
       /// </summary>
       /// <param name="usuarioViewModel"></param>
       /// <returns></returns>
        public UsuarioViewModel Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            var usuario = new UsuarioViewModel(new DateTime(1979, 2, 8));
            usuario = usuarioViewModel;
            return usuarioViewModel;
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
