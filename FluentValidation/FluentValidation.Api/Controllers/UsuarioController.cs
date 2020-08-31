using FluentValidation.Api.ViewModels;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace FluentValidation.Api.Controllers
{
    public class UsuarioController : ApiController
    {
       
       /// <summary>
       /// Insere um novo registro na tabela de usuarios
       /// </summary>
       /// <param name="usuarioViewModel"></param>
       /// <returns></returns>
        public HttpResponseMessage Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if (ModelState.IsValid)
            {
                //var usuario = _iMapper.Map<Usuario>(usuarioViewModel);
                //usuario = _usuarioService.Insert(usuario);

                //usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
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