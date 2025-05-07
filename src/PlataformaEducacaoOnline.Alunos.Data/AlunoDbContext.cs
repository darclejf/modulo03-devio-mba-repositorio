using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Data;
using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Alunos.Data
{
    public class AlunoDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Aluno> Alunos { get; set; }
        public AlunoDbContext(DbContextOptions<AlunoDbContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AlunoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.EnableSensitiveDataLogging(true);
            base.OnConfiguring(optionsBuilder);
        }

        public async Task<bool> CommitAsync()
        {
            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso)
                await _mediatorHandler.PublicarEventos(this);

            return sucesso;
        }
    }
}
