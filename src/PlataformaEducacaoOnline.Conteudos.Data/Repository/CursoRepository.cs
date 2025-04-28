using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Data;

namespace PlataformaEducacaoOnline.Conteudos.Data.Repository
{
    public class CursoRepository : ICursoRepository
    {
        private readonly ConteudoDbContext _context;

        public CursoRepository(ConteudoDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task AdicionarAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public Task<Curso> ObterPorIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _context.Cursos.ToListAsync();
        }
    }
}
