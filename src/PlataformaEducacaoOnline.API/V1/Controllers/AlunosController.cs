using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PlataformaEducacaoOnline.Alunos.Application.Commands;
using PlataformaEducacaoOnline.Alunos.Application.Queries;
using PlataformaEducacaoOnline.API.Controllers;
using PlataformaEducacaoOnline.API.Models;
using PlataformaEducacaoOnline.Conteudos.Application.Queries;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.DomainObjects;
using PlataformaEducacaoOnline.Core.Messages.Notifications;
using PlataformaEducacaoOnline.Financeiro.Business.Interfaces;

namespace PlataformaEducacaoOnline.API.V1.Controllers
{
    [Authorize(Roles = "ALUNO")]
    [ApiController]
    [ApiVersion("1.0")]
    [Route("api/v{version:apiVersion}/[Controller]")]
    public class AlunosController(INotificationHandler<DomainNotification> notifications, 
                                    IMediatorHandler mediatorHandler, 
                                    IAlunoQuery alunoQuery, 
                                    ICursoQuery cursoQuery,
                                    IPagamentoService pagamentoService,
                                    IUser user) : BaseController(notifications, mediatorHandler, user)
    {
        private readonly IAlunoQuery _alunoQuery = alunoQuery;
        private readonly ICursoQuery _cursoQuery = cursoQuery;
        private readonly IPagamentoService _pagamentoService = pagamentoService;

        [AllowAnonymous]
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

        [Authorize(Roles = "ADMINISTRADOR")]
        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var alunos = await _alunoQuery.ObterTodosAsync();
            return Ok(alunos);
        }

        [HttpPost("matricula")]
        public async Task<IActionResult> CriarMatricula(CriarMatriculaRequest request)
        {
            var command = new IniciarMatriculaCommand(request.CursoId, _appUser.GetId());
            if (command.Valido())
            {
                var resultado = await _mediatorHandler.EnviarComando(command);
                return CustomResponse(resultado);
            }
            return CustomResponse(command);
        }

        [HttpPut("matricula/{cursoId:guid}/pagar")]
        public async Task<IActionResult> PagarMatricula(Guid cursoId, RealizarPagamentoRequest request)
        {
            var aluno = await _alunoQuery.ObterPorUserIdAsync(_appUser.GetId());
            var resultado = await _pagamentoService.RealizarPagamentoCurso(new Core.DomainObjects.DTO.PagamentoCursoDTO
            {
                AlunoId = aluno.Id,
                CursoId = cursoId,
                CvvCartao = request.CvvCartao,
                ExpiracaoCartao = request.ExpiracaoCartao,
                NomeCartao = request.NomeCartao,
                NumeroCartao = request.NumeroCartao,
                Total = request.Total,
            });
            return CustomResponse(resultado);
        }

        [HttpGet("curso/{cursoId:guid}")]
        public async Task<IActionResult> ObterCurso(Guid cursoId)
        {
            var aluno = await _alunoQuery.ObterPorUserIdAsync(_appUser.GetId());
            if (!aluno.Matriculas.Any(x => x.CursoId == cursoId))
                throw new NotImplementedException();

            var curso = await _cursoQuery.ObterAsync(cursoId);    
            return CustomResponse(curso);
        }

        [HttpPut("curso/{cursoId:Guid}/iniciaraula")]
        public async Task<IActionResult> IniciarAula(Guid cursoId, IniciarAulaCursoRequest request)
        {
            var command = new IniciarAulaCommand(request.AulaId, cursoId, _appUser.GetId());
            if (command.Valido())
            {
                var resultado = await _mediatorHandler.EnviarComando(command);
                return CustomResponse(resultado);
            }
            return CustomResponse(command);
        }
    }
}
