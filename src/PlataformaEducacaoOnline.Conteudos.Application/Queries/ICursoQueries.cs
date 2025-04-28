using PlataformaEducacaoOnline.Conteudos.Application.Queries.Models;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries
{
    public interface ICursoQueries
    {
        Task<IEnumerable<CursoModel>> ObterTodos();
    }
}
