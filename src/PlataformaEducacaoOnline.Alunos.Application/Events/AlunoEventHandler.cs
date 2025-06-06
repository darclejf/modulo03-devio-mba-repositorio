using MediatR;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;

namespace PlataformaEducacaoOnline.Alunos.Application.Events
{
    public class AlunoEventHandler :
                        INotificationHandler<UsuarioCriadoIntegrationEvent>,
                        INotificationHandler<PagamentoRealizadoEvent>,
                        INotificationHandler<PagamentoRecusadoEvent>
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoEventHandler(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task Handle(UsuarioCriadoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(notification.AggregateId);
            aluno.VincularUsuario(notification.UserId);
            await _alunoRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(PagamentoRealizadoEvent notification, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(notification.AlunoId);
            aluno.MarcarMatriculaPaga(notification.CursoId);
            await _alunoRepository.UnitOfWork.CommitAsync();
        }

        public async Task Handle(PagamentoRecusadoEvent notification, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorIdAsync(notification.AlunoId);
            aluno.MarcarMatriculaRecusada(notification.CursoId);
            await _alunoRepository.UnitOfWork.CommitAsync();
        }
    }
}
