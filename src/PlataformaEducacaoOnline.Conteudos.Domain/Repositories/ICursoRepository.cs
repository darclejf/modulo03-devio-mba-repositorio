using PlataformaEducacaoOnline.Conteudos.Domain.Entities;
using PlataformaEducacaoOnline.Core.Data;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Repositories
{
    public interface ICursoRepository : IRepository<Curso>
    {
        Task<Curso?> ObterPorIdAsync(Guid id);
        Task InserirAsync(Curso curso);
        void Atualizar(Curso curso);
        Task<IEnumerable<Curso>> ObterTodosAsync();
    }
}
