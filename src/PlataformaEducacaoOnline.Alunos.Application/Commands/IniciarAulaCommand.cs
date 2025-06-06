using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Alunos.Application.Commands
{
    public class IniciarAulaCommand : Command
    {
        public Guid UserId { get; set; }
        public Guid AulaId { get; set; }
        public Guid CursoId { get; set; }

        public IniciarAulaCommand(Guid userId, Guid aulaId, Guid cursoId)
        {
            UserId = userId;
            AulaId = aulaId;
            CursoId = cursoId;
        }
    }
}
