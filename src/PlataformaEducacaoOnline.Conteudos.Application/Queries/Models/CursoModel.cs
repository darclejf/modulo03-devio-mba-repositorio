namespace PlataformaEducacaoOnline.Conteudos.Application.Queries.Models
{
    public class CursoModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
        public IList<AulaModel> Aulas { get; set; } = [];
    }
}
