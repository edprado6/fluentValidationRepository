using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FluentValidation.Api.Controllers
{
    public class UsuarioSemValidacaoController : ApiController
    {
        public UsuarioService _usuarioService;

        
        public UsuarioSemValidacaoController()
        {
            _usuarioService = new UsuarioService();           
        }

        /// <summary>
        /// Insere um novo registro na tabela de usuarios
        /// </summary>
        /// <param name="usuario"></param>       
        /// <returns>Um novo registro foi criado</returns>
        /// <response code="201">Retorna o novo registro criado</response>
        /// <response code="400">Um ou mais erros ocorreram</response>
        [ResponseType(typeof(Usuario))]
        public HttpResponseMessage Post([FromBody]Usuario usuario)
        {
            if (usuario == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum dado enviado para cadastro.");

            if (ModelState.IsValid)
            {                
                usuario = _usuarioService.Insert(usuario);
                
                return Request.CreateResponse(HttpStatusCode.Created, usuario);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}
