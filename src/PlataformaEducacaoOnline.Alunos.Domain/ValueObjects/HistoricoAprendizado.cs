using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Alunos.Domain.ValueObjects
{
    public class HistoricoAprendizado : Entity
    {
        public Guid MatriculaId { get; private set; }
        public Guid AulaId { get; private set; }
        public bool Concluido { get; private set; }
        
        public HistoricoAprendizado(Guid id, Guid aulaId, Guid matriculaId) 
        {
            Id = id;
            MatriculaId = matriculaId;
            AulaId = aulaId;
            Concluido = false;
        }

        internal void Concluir()
        {
            Concluido = true;
        }

        internal void NaoConcluir()
        {
            Concluido = false;
        }
    }
}
