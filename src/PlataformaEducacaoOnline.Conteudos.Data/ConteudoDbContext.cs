using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Data;
using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Conteudos.Data
{
    public class ConteudoDbContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public DbSet<Curso> Cursos { get; set; }
        public DbSet<Aula> Aulas { get; set; }

        public ConteudoDbContext(DbContextOptions<ConteudoDbContext> options, IMediatorHandler mediatorHandler) : base(options)
        {
            _mediatorHandler = mediatorHandler;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Ignore<Event>();
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(ConteudoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
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
