using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacaoOnline.API.Controllers;
using PlataformaEducacaoOnline.API.Models;
using PlataformaEducacaoOnline.Conteudos.Application.Commands;
using PlataformaEducacaoOnline.Conteudos.Application.Queries;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Constants;
using PlataformaEducacaoOnline.Core.Messages.Notifications;
using System.Net;

namespace PlataformaEducacaoOnline.API.V1.Controllers
{
    //[Authorize(Roles = "ADMINISTRADOR")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]

    public class CursosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, ICursoQuery cursoQueries) : BaseController(notifications, mediatorHandler)
    {
        private readonly ICursoQuery _cursoQueries = cursoQueries;

        [HttpPost]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Post(NovoCursoRequest request)
        {
            var command = new AdicionarCursoCommand(request.Nome, request.Descricao, request.DataInicio, request.DataConclusao);
            if (command.Valido())
            {
                var resultado = await _mediatorHandler.EnviarComando(command);
                return CustomResponse(resultado);
            }
            return CustomResponse(command);
        }

        [HttpPost("{id:guid}/aula")]
        [Produces("application/json")]
        [Consumes("application/json")]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status200OK)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status400BadRequest)]
        [ProducesResponseType(typeof(ActionResult), StatusCodes.Status500InternalServerError)]
        public async Task<IActionResult> Put(Guid id, NovaAulaRequest request)
        {
            //if (id != request.CursoId)
            //    return null;
            var command = new AdicionarAulaCursoCommand(id, request.Titulo, request.Titulo, request.Descricao, request.Tipo, request.Url);
            if (command.Valido())
            {
                var resultado = await _mediatorHandler.EnviarComando(command);
                return CustomResponse(resultado);
            }
            return CustomResponse(command);
        }

        [AllowAnonymous]
        [HttpGet]        
        public async Task<IActionResult> Get()
        {
            var cursos = await _cursoQueries.ObterTodos();
            return Ok(cursos);
        }
    }
}
