using PlataformaEducacaoOnline.Alunos.Domain.Enums;

namespace PlataformaEducacaoOnline.Alunos.Application.Queries.Model
{
    public class MatriculaModel
    {
        public Guid AlunoId { get; set; }
        public Guid CursoId { get; set; }
        public DateTime DataMatricula { get; set; }
        public decimal Percentual { get; set; }
        public EnumStatusMatricula Status { get; set; }
    }
}
