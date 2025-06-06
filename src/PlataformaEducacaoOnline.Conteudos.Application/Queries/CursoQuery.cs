using PlataformaEducacaoOnline.Conteudos.Application.Queries.Extensions;
using PlataformaEducacaoOnline.Conteudos.Application.Queries.Models;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries
{
    public class CursoQuery : ICursoQuery
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoQuery(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<CursoModel?> ObterAsync(Guid id)
        {
            var curso = await _cursoRepository.ObterPorIdAsyncAsNoTracking(id);
            return curso?.ToModel();
        }

        public async Task<IEnumerable<CursoModel>> ObterTodosAsync()
        {
            var cursos = await _cursoRepository.ObterTodosAsync();
            return cursos.Select(x => x.ToModel());
        }
    }
}
