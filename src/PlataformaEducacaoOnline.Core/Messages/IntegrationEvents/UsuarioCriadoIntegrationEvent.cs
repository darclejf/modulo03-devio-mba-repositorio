namespace PlataformaEducacaoOnline.Core.Messages.IntegrationEvents
{
    public class UsuarioCriadoIntegrationEvent : IntegrationEvent
    {
        public Guid UserId { get; private set; }

        public UsuarioCriadoIntegrationEvent(Guid aggregateId, Guid userId)
        {
            AggregateId = aggregateId;
            UserId = userId;
        }
    }
}
