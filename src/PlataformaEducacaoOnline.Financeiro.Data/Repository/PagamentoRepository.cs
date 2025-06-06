using PlataformaEducacaoOnline.Core.Data;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;
using PlataformaEducacaoOnline.Financeiro.Business.Interfaces;

namespace PlataformaEducacaoOnline.Financeiro.Data.Repository
{
    public class PagamentoRepository : IPagamentoRepository
    {
        private readonly FinanceiroDBContext _context;

        public PagamentoRepository(FinanceiroDBContext context)
        {
            _context = context;
        }

        public IUnitOfWork UnitOfWork => _context;


        public void Adicionar(Pagamento pagamento)
        {
            _context.Pagamentos.Add(pagamento);
        }

        public void AdicionarTransacao(Transacao transacao)
        {
            _context.Transacoes.Add(transacao);
        }

        public void Dispose()
        {
            _context.Dispose();
        }
    }
}
