using PlataformaEducacaoOnline.Alunos.Application.Queries.Model;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;

namespace PlataformaEducacaoOnline.Alunos.Application.Queries.Extensions
{
    public static class AlunoExtensions
    {
        public static AlunoModel ToModel(this Aluno aluno)
        {
            var model = new AlunoModel
            {
                Id = aluno.Id,
                Nome = aluno.Nome,
                Ativo = aluno.Ativo,
                DataCadastro = aluno.DataCadastro,
                DataNascimento = aluno.DataNascimento,
                Email = aluno.Email,
                Sobrenome = aluno.Sobrenome,
                UserId = aluno.UserId,
                Matriculas = aluno.Matriculas.Select(y => new MatriculaModel
                {
                    AlunoId = y.AlunoId,
                    CursoId = y.CursoId,
                    DataMatricula = y.DataMatricula,
                    Percentual = y.Percentual,
                    Status = y.Status,
                }).ToList()
            };
            return model;
        }
    }
}
