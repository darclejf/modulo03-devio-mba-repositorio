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

            //TODO
            builder.Ignore(c => c.Historico);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
