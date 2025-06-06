using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Alunos.Application.Commands
{
    public class IniciarMatriculaCommand(Guid cursoId, Guid userId) : Command
    {
        public Guid CursoId { get; private set; } = cursoId;
        public Guid UserId { get; private set; } = userId;

        public override bool Valido()
        {
            return true;
        }
    }
}
