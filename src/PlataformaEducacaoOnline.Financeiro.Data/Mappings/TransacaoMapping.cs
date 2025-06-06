using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;

namespace PlataformaEducacaoOnline.Financeiro.Data.Mappings
{
    public class TransacaoMapping : IEntityTypeConfiguration<Transacao>
    {
        public void Configure(EntityTypeBuilder<Transacao> builder)
        {
            builder.ToTable("plataformaead_transacoes");

            builder.HasKey(a => a.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
