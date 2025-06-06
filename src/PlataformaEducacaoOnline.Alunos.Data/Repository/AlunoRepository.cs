using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Data;

namespace PlataformaEducacaoOnline.Alunos.Data.Repository
{
    public class AlunoRepository : IAlunoRepository
    {
        private readonly AlunoDbContext _context;

        public AlunoRepository(AlunoDbContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;

        public async Task InserirAsync(Aluno aluno)
        {
            await _context.Alunos.AddAsync(aluno);
        }

        public void Atualizar(Aluno aluno)
        {
            _context.Alunos.Update(aluno);
        }

        public void Dispose()
        {
            _context.Dispose();
        }

        public async Task<Aluno?> ObterPorIdAsync(Guid id)
        {
            return await _context.Alunos
                                    .Include(a => a.Matriculas)
                                        .ThenInclude(a => a.Historico)
                                    .SingleOrDefaultAsync(x => x.Id == id);
        }

        public async Task<IEnumerable<Aluno>> ObterTodosAsync()
        {
            return await _context.Alunos
                                    .Include(a => a.Matriculas)
                                        .ThenInclude(a => a.Historico)
                                    .AsNoTracking().ToListAsync();
        }

        public async Task<Aluno?> ObterPorUserIdAsync(Guid userId)
        {
            return await _context.Alunos
                                    .Include(a => a.Matriculas)
                                        .ThenInclude(a => a.Historico)
                                    .SingleOrDefaultAsync(x => x.UserId == userId);
        }
    }
}
