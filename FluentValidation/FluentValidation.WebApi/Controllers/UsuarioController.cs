using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using FluentValidation.WebApi.ViewModels.Entities;
using System;
using System.Collections.Generic;
using System.Web.Http;

namespace FluentValidation.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        private UsuarioService _usuarioService;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
        }
        // GET: api/Usuario
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public Usuario Get(long id)
        {
            var usuarioViewModel = _usuarioService.GetById(id);

            return usuarioViewModel;
        }

        // POST: api/Usuario
        public UsuarioViewModel Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            var usuario = new UsuarioViewModel(new DateTime(1979, 2, 8));
            usuario = usuarioViewModel;
            return usuarioViewModel;
        }

        // PUT: api/Usuario/5
        public UsuarioViewModel Put(int id, [FromBody]UsuarioViewModel usuarioViewModel)
        {
            return usuarioViewModel;
        }

        // DELETE: api/Usuario/5
        public void Delete(int id)
        {

        }
    }
}
