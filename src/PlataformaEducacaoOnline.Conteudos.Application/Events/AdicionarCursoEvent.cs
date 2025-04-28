using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Conteudos.Application.Events
{
    public class AdicionarCursoEvent : Event
    {
        public Guid CursoId { get; private set; }

        public AdicionarCursoEvent(Guid cursoId)
        {
            CursoId = cursoId;
            AggregateId = cursoId;
        }
    }
}
