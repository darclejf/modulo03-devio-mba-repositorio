namespace PlataformaEducacaoOnline.Core.Messages.IntegrationEvents
{
    public class PagamentoRealizadoEvent : IntegrationEvent
    {
        public Guid CursoId { get; private set; }
        public Guid AlunoId { get; private set; }
        public Guid PagamentoId { get; private set; }
        public Guid TransacaoId { get; private set; }
        public decimal Total { get; private set; }

        public PagamentoRealizadoEvent(Guid cursoId, Guid alunoId, Guid pagamentoId, Guid transacaoId, decimal total)
        {
            AggregateId = pagamentoId;
            CursoId = cursoId;
            AlunoId = alunoId;
            PagamentoId = pagamentoId;
            TransacaoId = transacaoId;
            Total = total;
        }
    }
}
