using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;

namespace PlataformaEducacaoOnline.Alunos.Data.Mappings
{
    public class MatriculaMapping : IEntityTypeConfiguration<Matricula>
    {
        public void Configure(EntityTypeBuilder<Matricula> builder)
        {
            builder.ToTable("plataformaead_matriculas");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.HasMany(c => c.Historico)
                    .WithOne()
                    .HasForeignKey(c => c.MatriculaId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
