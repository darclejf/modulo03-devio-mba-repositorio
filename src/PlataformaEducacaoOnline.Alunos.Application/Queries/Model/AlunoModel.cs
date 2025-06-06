namespace PlataformaEducacaoOnline.Alunos.Application.Queries.Model
{
    public class AlunoModel
    {
        public Guid Id { get; set; }
        public string? Nome { get; set; } = string.Empty;
        public string? Sobrenome { get; set; } = string.Empty;
        public DateTime DataNascimento { get; set; }
        public DateTime DataCadastro { get; set; }
        public string? Email { get; set; } = string.Empty;
        public bool Ativo { get; set; }
        public Guid? UserId { get; set; }
        public string? UserName { get; set; }
        public IList<MatriculaModel> Matriculas { get; set; } = [];
    }
}
