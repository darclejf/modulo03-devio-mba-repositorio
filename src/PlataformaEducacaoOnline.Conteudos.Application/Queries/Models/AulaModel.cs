using PlataformaEducacaoOnline.Conteudos.Domain.ValueObjects;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries.Models
{
    public class AulaModel
    {
        public Guid Id { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public int Ordem { get; set; }
        public ConteudoProgramatico? Conteudo { get; set; } = null;
        public Guid CursoId { get; set; }
        public bool Ativo { get; set; }
    }
}
