using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Data.Mappings
{
    public class AulaMapping : IEntityTypeConfiguration<Aula>
    {
        public void Configure(EntityTypeBuilder<Aula> builder)
        {
            builder.ToTable("plataformaead_aulas");

            builder.HasKey(a => a.Id);

            builder.OwnsOne(a => a.Conteudo)
                .Property(a => a.Titulo)
                .HasColumnType("varchar(150)")
                .IsRequired(true);

            builder.OwnsOne(a => a.Conteudo)
                .Property(a => a.Descricao)
                .HasColumnType("varchar(5000)");

            builder.OwnsOne(a => a.Conteudo)
                .Property(a => a.Tipo)
                .HasColumnType("varchar(20)")
                .IsRequired(true);

            builder.OwnsOne(a => a.Conteudo)
                .Property(a => a.Url)
                .HasColumnType("varchar(400)")
                .IsRequired(true);

            builder.Ignore(c => c.ValidationResult);
        }
    }
}
