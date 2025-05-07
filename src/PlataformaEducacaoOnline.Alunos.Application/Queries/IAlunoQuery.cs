using PlataformaEducacaoOnline.Alunos.Application.Queries.Model;

namespace PlataformaEducacaoOnline.Alunos.Application.Queries
{
    public interface IAlunoQuery
    {
        Task<IEnumerable<AlunoModel>> ObterTodos();
    }
}
