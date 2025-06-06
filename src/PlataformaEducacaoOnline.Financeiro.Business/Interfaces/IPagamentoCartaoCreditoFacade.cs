using PlataformaEducacaoOnline.Financeiro.Business.Entities;

namespace PlataformaEducacaoOnline.Financeiro.Business.Interfaces
{
    public interface IPagamentoCartaoCreditoFacade
    {
        Transacao RealizarPagamento(Curso curso, Pagamento pagamento);
    }
}
