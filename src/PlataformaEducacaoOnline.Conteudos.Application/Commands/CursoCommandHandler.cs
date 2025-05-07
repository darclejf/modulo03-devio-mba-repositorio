using MediatR;
using PlataformaEducacaoOnline.Conteudos.Application.Events;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages;
using PlataformaEducacaoOnline.Core.Messages.Notifications;

namespace PlataformaEducacaoOnline.Conteudos.Application.Commands
{
    public class CursoCommandHandler :
        IRequestHandler<AdicionarCursoCommand, bool>,
        IRequestHandler<AdicionarAulaCursoCommand, bool>
    {
        private readonly ICursoRepository _cursoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public CursoCommandHandler(ICursoRepository cursoRepository, IMediatorHandler mediatorHandler)
        {
            _cursoRepository = cursoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(AdicionarCursoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request)) 
                return false;

            var curso = new Curso(
                                Guid.NewGuid(),
                                request.Nome,
                                request.Descricao,
                                request.DataInicio,
                                request.DataConclusao);

            if (curso.Valido())
            {
                await _cursoRepository.InserirAsync(curso);
                curso.AdicionarEvento(new AdicionarCursoEvent(curso.Id));
                await _cursoRepository.UnitOfWork.CommitAsync();
                return true;
            }

            foreach (var error in curso.ValidationResult.Errors)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", error.ErrorMessage));
            }
            return false;            
        }

        public async Task<bool> Handle(AdicionarAulaCursoCommand request, CancellationToken cancellationToken)
        {
            if (!ValidarComando(request))
                return false;

            var curso = await _cursoRepository.ObterPorIdAsync(request.CursoId);

            if (curso == null)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("curso", "Curso não encontrado!"));
                return false;
            }

            var aula = curso.AdicionarAula(request.Nome, request.Titulo, request.Descricao, request.Tipo, request.Url);

            if (aula.Valido())
            {
                await _cursoRepository.UnitOfWork.CommitAsync();
                return true;
            }

            foreach (var error in aula.ValidationResult.Errors)
            {
                await _mediatorHandler.PublicarNotificacao(new DomainNotification("aula", error.ErrorMessage));
            }
            return false;

        }

        private bool ValidarComando(Command message)
        {
            if (message.Valido()) 
                return true;

            foreach (var error in message.ValidationResult.Errors)
            {
                _mediatorHandler.PublicarNotificacao(new DomainNotification(message.MessageType, error.ErrorMessage));
            }

            return false;
        }

    }
}
