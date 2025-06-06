using PlataformaEducacaoOnline.Conteudos.Application.Queries.Models;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries.Extensions
{
    public static class CursoExtensions
    {
        public static CursoModel ToModel(this Curso curso)
        {
            var model = new CursoModel
            {
                Id = curso.Id,
                Nome = curso.Nome,
                DataConclusao = curso.DataConclusao,
                DataInicio = curso.DataInicio,
                Descricao = curso.Descricao,
                Aulas = curso.Aulas.Select(y => new AulaModel
                {
                    Id = y.Id,
                    Ativo = y.Ativo,
                    Conteudo = y.Conteudo,
                    CursoId = y.CursoId,
                    Ordem = y.Ordem,
                    Titulo = y.Titulo,
                }).ToList(),
            };
            return model;
        }
    }
}
