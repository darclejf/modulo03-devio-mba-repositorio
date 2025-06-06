using PlataformaEducacaoOnline.Core.Data;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;

namespace PlataformaEducacaoOnline.Financeiro.Business.Interfaces
{
    public interface IPagamentoRepository : IRepository<Pagamento>
    {
        void Adicionar(Pagamento pagamento);
        void AdicionarTransacao(Transacao transacao);
    }
}
