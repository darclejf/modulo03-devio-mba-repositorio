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

        public async Task InserirAsync(Curso curso)
        {
            await _context.Cursos.AddAsync(curso);
        }

        public void Atualizar(Curso curso)
        {
            _context.Cursos.Update(curso);            
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Curso?> ObterPorIdAsync(Guid id)
        {
            return await _context.Cursos
                                    .Include(x => x.Aulas)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<Curso?> ObterPorIdAsyncAsNoTracking(Guid id)
        {
            return await _context.Cursos
                                    .AsNoTracking()
                                    .Include(x => x.Aulas)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Curso>> ObterTodosAsync()
        {
            return await _context.Cursos
                                    .Include(x => x.Aulas)
                                    .AsNoTracking().ToListAsync();
        }
    }
}
