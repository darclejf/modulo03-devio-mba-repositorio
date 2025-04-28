using PlataformaEducacaoOnline.Conteudos.Application.Queries.Models;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries
{
    public class CursoQueries : ICursoQueries
    {
        private readonly ICursoRepository _cursoRepository;

        public CursoQueries(ICursoRepository cursoRepository)
        {
            _cursoRepository = cursoRepository;
        }

        public async Task<IEnumerable<CursoModel>> ObterTodos()
        {
            var cursos = await _cursoRepository.ObterTodosAsync();
            return cursos.Select(x => new CursoModel
            {
                Id = x.Id,
                Nome = x.Nome,
                DataConclusao = x.DataConclusao,
                DataInicio = x.DataInicio,
                Descricao = x.Descricao,
                Aulas = x.Aulas.Select(y => new AulaModel
                {
                    Id = y.Id,
                    Ativo = y.Ativo,
                    Conteudo = y.Conteudo,
                    CursoId = y.CursoId,
                    Ordem = y.Ordem,
                    Titulo = y.Titulo,
                }).ToList()
            });
        }
    }
}
