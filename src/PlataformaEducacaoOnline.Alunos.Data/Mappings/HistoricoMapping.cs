using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaEducacaoOnline.Alunos.Domain.ValueObjects;

namespace PlataformaEducacaoOnline.Alunos.Data.Mappings
{
    public class HistoricoMapping : IEntityTypeConfiguration<HistoricoAprendizado>
    {
        public void Configure(EntityTypeBuilder<HistoricoAprendizado> builder)
        {
            builder.ToTable("plataformaead_matriculas_historico");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
