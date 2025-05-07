using MediatR;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;

namespace PlataformaEducacaoOnline.Alunos.Application.Events
{
    public class AlunoEventHandler :
         INotificationHandler<UsuarioCriadoIntegrationEvent>
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
    }
}
