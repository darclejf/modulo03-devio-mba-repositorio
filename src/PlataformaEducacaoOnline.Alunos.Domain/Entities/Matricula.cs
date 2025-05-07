using PlataformaEducacaoOnline.Alunos.Domain.Enums;
using PlataformaEducacaoOnline.Alunos.Domain.Events;
using PlataformaEducacaoOnline.Alunos.Domain.ValueObjects;
using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Alunos.Domain.Entities
{
    public class Matricula : Entity
    {
        public Guid AlunoId { get; private set; }
        public Guid CursoId { get; private set; }
        public DateTime DataMatricula {  get; private set; }        
        public decimal Percentual { get; private set; }
        public EnumStatusMatricula Status { get; private set; }
        public IList<HistoricoAprendizado> Historico { get; private set; } = [];

        protected Matricula() { }

        public static Matricula Create(Guid alunoId, Guid cursoId, IList<Guid> aulas)
        {
            return new Matricula
            {
                AlunoId = alunoId,
                CursoId = cursoId,
                DataMatricula = DateTime.Now,
                Percentual = 0,
                Status = EnumStatusMatricula.PendentePagamento,
                Historico = aulas.Select(x => new HistoricoAprendizado(x)).ToList()
            };
        }

        internal void MarcarAulaConcluida(Guid aulaId)
        {
            var historico = Historico.FirstOrDefault(x => x.AulaId == aulaId);
            if (historico == null)
            {
                throw new DomainException("Aula não encontrada");
            }

            historico.MarcarConcluido();
            AdicionarEvento(new CursoConcluidoEvent(aulaId));
        }

        internal void MarcarPaga()
        {
            Status = EnumStatusMatricula.Ativo;
        }

        internal void MarcarConcluida()
        {
            Status = EnumStatusMatricula.Concluido;
            AdicionarEvento(new CursoConcluidoEvent(CursoId));
        }
    }
}
