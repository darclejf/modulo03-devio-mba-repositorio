﻿using PlataformaEducacaoOnline.Conteudos.Application.Queries.Models;

namespace PlataformaEducacaoOnline.Conteudos.Application.Queries
{
    public interface ICursoQuery
    {
        Task<IEnumerable<CursoModel>> ObterTodosAsync();
        Task<CursoModel?> ObterAsync(Guid id);
    }
}
