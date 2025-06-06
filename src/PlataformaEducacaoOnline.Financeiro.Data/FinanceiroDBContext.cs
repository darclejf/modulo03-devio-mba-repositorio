using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Data;
using PlataformaEducacaoOnline.Core.Messages;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;

namespace PlataformaEducacaoOnline.Financeiro.Data
{
    public class FinanceiroDBContext : DbContext, IUnitOfWork
    {
        private readonly IMediatorHandler _mediatorHandler;

        public FinanceiroDBContext(DbContextOptions<FinanceiroDBContext> options, IMediatorHandler rebusHandler)
            : base(options)
        {
            _mediatorHandler = rebusHandler ?? throw new ArgumentNullException(nameof(rebusHandler));
        }

        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Transacao> Transacoes { get; set; }


        public async Task<bool> CommitAsync()
        {
            foreach (var entry in ChangeTracker.Entries().Where(entry => entry.Entity.GetType().GetProperty("DataCadastro") != null))
            {
                if (entry.State == EntityState.Added)
                {
                    entry.Property("DataCadastro").CurrentValue = DateTime.Now;
                }

                if (entry.State == EntityState.Modified)
                {
                    entry.Property("DataCadastro").IsModified = false;
                }
            }

            var sucesso = await base.SaveChangesAsync() > 0;
            if (sucesso) 
                await _mediatorHandler.PublicarEventos(this);
            return sucesso;
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //foreach (var property in modelBuilder.Model.GetEntityTypes().SelectMany(
            //    e => e.GetProperties().Where(p => p.ClrType == typeof(string)))) ;
            //    //property.Relational().ColumnType = "varchar(100)";

            modelBuilder.Ignore<Event>();

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(FinanceiroDBContext).Assembly);

            //foreach (var relationship in modelBuilder.Model.GetEntityTypes().SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(modelBuilder);
        }
    }
}
