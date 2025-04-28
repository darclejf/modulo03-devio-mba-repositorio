using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace PlataformaEducacaoOnline.Autenticacao.Data
{
    public class AutenticacaoDbContext : IdentityDbContext<IdentityUser<Guid>, IdentityRole<Guid>, Guid>
    {
        public AutenticacaoDbContext(DbContextOptions<AutenticacaoDbContext> options) : base(options) { }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(AutenticacaoDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
