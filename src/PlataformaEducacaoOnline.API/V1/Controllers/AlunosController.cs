using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacaoOnline.Alunos.Application.Commands;
using PlataformaEducacaoOnline.Alunos.Application.Queries;
using PlataformaEducacaoOnline.API.Controllers;
using PlataformaEducacaoOnline.API.Models;
using PlataformaEducacaoOnline.Conteudos.Application.Queries;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages.Notifications;

namespace PlataformaEducacaoOnline.API.V1.Controllers
{
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class AlunosController(INotificationHandler<DomainNotification> notifications, IMediatorHandler mediatorHandler, IAlunoQuery alunoQuery) : BaseController(notifications, mediatorHandler)
    {
        private readonly IAlunoQuery _alunoQuery = alunoQuery;

        [HttpPost]
        public async Task<ActionResult> Post(NovoAlunoRequest request)
        {
            var command = new NovoAlunoCommand(
                                    email: request.Email,
                                    password: request.Password,
                                    confirmPassword: request.ConfirmPassword,
                                    nome: request.Nome,
                                    sobrenome: request.Sobrenome,
                                    dataNascimento: request.DataNascimento);

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
            var alunos = await _alunoQuery.ObterTodos();
            return Ok(alunos);
        }
    }
}
