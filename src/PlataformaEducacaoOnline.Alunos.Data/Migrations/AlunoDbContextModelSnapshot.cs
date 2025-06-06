﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using PlataformaEducacaoOnline.Alunos.Data;

#nullable disable

namespace PlataformaEducacaoOnline.Alunos.Data.Migrations
{
    [DbContext(typeof(AlunoDbContext))]
    partial class AlunoDbContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder.HasAnnotation("ProductVersion", "9.0.4");

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.Entities.Aluno", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Ativo")
                        .HasColumnType("INTEGER");

                    b.Property<DateTime>("DataCadastro")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataNascimento")
                        .HasColumnType("TEXT");

                    b.Property<string>("Email")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Nome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<string>("Sobrenome")
                        .IsRequired()
                        .HasColumnType("varchar(150)");

                    b.Property<Guid?>("UserId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.ToTable("plataformaead_alunos", (string)null);
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.Entities.Matricula", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AlunoId")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("CursoId")
                        .HasColumnType("TEXT");

                    b.Property<DateTime>("DataMatricula")
                        .HasColumnType("TEXT");

                    b.Property<decimal>("Percentual")
                        .HasColumnType("TEXT");

                    b.Property<int>("Status")
                        .HasColumnType("INTEGER");

                    b.HasKey("Id");

                    b.HasIndex("AlunoId");

                    b.ToTable("plataformaead_matriculas", (string)null);
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.ValueObjects.HistoricoAprendizado", b =>
                {
                    b.Property<Guid>("Id")
                        .HasColumnType("TEXT");

                    b.Property<Guid>("AulaId")
                        .HasColumnType("TEXT");

                    b.Property<bool>("Concluido")
                        .HasColumnType("INTEGER");

                    b.Property<Guid>("MatriculaId")
                        .HasColumnType("TEXT");

                    b.HasKey("Id");

                    b.HasIndex("MatriculaId");

                    b.ToTable("plataformaead_matriculas_historico", (string)null);
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.Entities.Matricula", b =>
                {
                    b.HasOne("PlataformaEducacaoOnline.Alunos.Domain.Entities.Aluno", null)
                        .WithMany("Matriculas")
                        .HasForeignKey("AlunoId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.ValueObjects.HistoricoAprendizado", b =>
                {
                    b.HasOne("PlataformaEducacaoOnline.Alunos.Domain.Entities.Matricula", null)
                        .WithMany("Historico")
                        .HasForeignKey("MatriculaId")
                        .OnDelete(DeleteBehavior.Cascade)
                        .IsRequired();
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.Entities.Aluno", b =>
                {
                    b.Navigation("Matriculas");
                });

            modelBuilder.Entity("PlataformaEducacaoOnline.Alunos.Domain.Entities.Matricula", b =>
                {
                    b.Navigation("Historico");
                });
#pragma warning restore 612, 618
        }
    }
}
