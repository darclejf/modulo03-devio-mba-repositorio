using PlataformaEducacaoOnline.Core.DomainObjects.DTO;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;

namespace PlataformaEducacaoOnline.Financeiro.Business.Interfaces
{
    public interface IPagamentoService
    {
        Task<Transacao> RealizarPagamentoCurso(PagamentoCursoDTO pagamentoCurso);
    }
}
