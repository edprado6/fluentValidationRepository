using AutoMapper;
using FluentValidation.Api.Mappers;
using FluentValidation.Api.ViewModels;
using FluentValidation.Domain.Entities;
using FluentValidation.Services;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;

namespace FluentValidation.Api.Controllers
{
    public class UsuarioController : ApiController
    {

        public UsuarioService _usuarioService;

        public IMapper _iMapper;

        public UsuarioController()
        {
            _usuarioService = new UsuarioService();
            _iMapper = new AutoMapperConfig().IMapper();
        }

        /// <summary>
        /// Retorna um unico usuario.
        /// </summary>
        /// <param name="id"></param>        
        /// <returns>Retorna um registro a partir do parâmetro especificado</returns>
        /// <response code="200">A busca retornou resultado</response>
        /// <response code="404">A busca não retornou resultados</response>
        [ResponseType(typeof(UsuarioViewModel))]
        public HttpResponseMessage Get(long id)
        {            
            var usuario = _usuarioService.GetById(id);
            if (usuario != null)
            {
                var usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
                return Request.CreateResponse(HttpStatusCode.OK, usuarioViewModel);
            }

            return Request.CreateErrorResponse(HttpStatusCode.NotFound, "Nenhum registro encontrado.");
        }

        /// <summary>
        /// Insere um novo registro na tabela de usuarios
        /// </summary>
        /// <param name="usuarioViewModel"></param>       
        /// <returns>Um novo registro foi criado</returns>
        /// <response code="201">Retorna o novo registro criado</response>
        /// <response code="400">Um ou mais erros ocorreram</response>
        [ResponseType(typeof(UsuarioViewModel))]
        public HttpResponseMessage Post([FromBody]UsuarioViewModel usuarioViewModel)
        {
            if(usuarioViewModel == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum dado enviado para cadastro.");

            if (ModelState.IsValid)
            {
                var usuario = _iMapper.Map<Usuario>(usuarioViewModel);
                usuario = _usuarioService.Insert(usuario);

                usuarioViewModel = _iMapper.Map<UsuarioViewModel>(usuario);
                return Request.CreateResponse(HttpStatusCode.Created, usuarioViewModel);
            }  
            
            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }

        /// <summary>
        /// Atualiza um registro na tabela de usuarios
        /// </summary>
        /// <param name="id"></param>
        /// <param name="usuarioViewModel"></param>
        /// <returns>Um registro foi atualizado</returns>
        /// <response code="204">Registro encontrado e atualizado</response>
        /// <response code="400">Um ou mais erros ocorreram</response>
        /// <response code="404">Nenhum registro encontrado para atualização</response>        
        [ResponseType(typeof(UsuarioViewModel))]
        public HttpResponseMessage Put(long id, [FromBody]UsuarioViewModel usuarioViewModel)
        {            
            if (usuarioViewModel == null) return Request.CreateErrorResponse(HttpStatusCode.BadRequest, "Nenhum dado enviado para atualização.");
                      
            if (ModelState.IsValid)
            {                
                var usuario = _iMapper.Map<Usuario>(usuarioViewModel);
                usuario = _usuarioService.Update(id, usuario);

                if (usuario == null) { return Request.CreateResponse(HttpStatusCode.NotFound); }

                return Request.CreateResponse(HttpStatusCode.NoContent);
            }

            return Request.CreateErrorResponse(HttpStatusCode.BadRequest, ModelState);
        }
    }
}