using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;

namespace PlataformaEducacaoOnline.Alunos.Data.Mappings
{
    public class AlunoMapping : IEntityTypeConfiguration<Aluno>
    {
        public void Configure(EntityTypeBuilder<Aluno> builder)
        {
            builder.ToTable("plataformaead_alunos");

            builder.HasKey(c => c.Id);

            builder.Property(c => c.Id).ValueGeneratedNever();

            builder.Property(p => p.Nome)
                    .HasColumnType("varchar(150)")
                    .IsRequired(true);

            builder.Property(p => p.Sobrenome)
                    .HasColumnType("varchar(150)")
                    .IsRequired(true);

            builder.Property(p => p.DataNascimento)
                    .IsRequired(true);

            builder.Property(p => p.Email)
                    .HasColumnType("varchar(150)")
                    .IsRequired(true);

            builder.HasMany(c => c.Matriculas)
                    .WithOne()
                    .HasForeignKey(c => c.AlunoId)
                    .OnDelete(DeleteBehavior.Cascade);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}

