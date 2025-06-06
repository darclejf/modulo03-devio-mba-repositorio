using PlataformaEducacaoOnline.Alunos.Domain.Entities;
using PlataformaEducacaoOnline.Core.Data;

namespace PlataformaEducacaoOnline.Alunos.Domain.Repositories
{
    public interface IAlunoRepository : IRepository<Aluno>
    {
        Task<Aluno?> ObterPorIdAsync(Guid id);
        Task<Aluno?> ObterPorUserIdAsync(Guid userId);
        Task InserirAsync(Aluno aluno);
        void Atualizar(Aluno aluno);
        Task<IEnumerable<Aluno>> ObterTodosAsync();
    }
}
