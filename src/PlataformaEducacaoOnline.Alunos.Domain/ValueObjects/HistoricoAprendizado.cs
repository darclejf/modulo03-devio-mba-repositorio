namespace PlataformaEducacaoOnline.Alunos.Domain.ValueObjects
{
    public class HistoricoAprendizado
    {
        public Guid AulaId { get; private set; }
        public bool Concluido { get; private set; }
        
        public HistoricoAprendizado(Guid aulaId) 
        { 
            AulaId = aulaId;
            Concluido = false;
        }

        internal void MarcarConcluido()
        {
            Concluido = true;
        }

        internal void MarcarNaoConcluido()
        {
            Concluido = false;
        }
    }
}
