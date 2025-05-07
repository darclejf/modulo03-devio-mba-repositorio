using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Data.Mappings
{
    public class CursoMapping : IEntityTypeConfiguration<Curso>
    {
        public void Configure(EntityTypeBuilder<Curso> builder)
        {
            builder.ToTable("plataformaead_cursos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(p => p.Nome)
                    .HasColumnType("varchar(150)")
                    .IsRequired(true); ;

            builder.HasMany(c => c.Aulas)
                    .WithOne()
                    .HasForeignKey(c => c.CursoId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
