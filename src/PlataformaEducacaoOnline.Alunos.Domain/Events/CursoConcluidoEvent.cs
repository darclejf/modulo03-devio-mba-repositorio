using PlataformaEducacaoOnline.Core.Messages.DomainEvents;

namespace PlataformaEducacaoOnline.Alunos.Domain.Events
{
    public class CursoConcluidoEvent : DomainEvent
    {
        public CursoConcluidoEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
