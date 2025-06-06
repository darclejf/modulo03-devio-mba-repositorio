using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.DomainObjects.DTO;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;
using PlataformaEducacaoOnline.Core.Messages.Notifications;
using PlataformaEducacaoOnline.Financeiro.Business.Entities;
using PlataformaEducacaoOnline.Financeiro.Business.Interfaces;

namespace PlataformaEducacaoOnline.Financeiro.Business.Services
{
    public class PagamentoService : IPagamentoService
    {
        private readonly IPagamentoCartaoCreditoFacade _pagamentoCartaoCreditoFacade;
        private readonly IPagamentoRepository _pagamentoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public PagamentoService(IPagamentoCartaoCreditoFacade pagamentoCartaoCreditoFacade, IPagamentoRepository pagamentoRepository, IMediatorHandler mediatorHandler)
        {
            _pagamentoCartaoCreditoFacade = pagamentoCartaoCreditoFacade;
            _pagamentoRepository = pagamentoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<Transacao> RealizarPagamentoCurso(PagamentoCursoDTO pagamentoCurso)
        {
            var curso = new Curso
            {
                Id = pagamentoCurso.CursoId,
                Valor = pagamentoCurso.Total
            };

            var pagamento = new Pagamento
            {
                Id = Guid.NewGuid(),
                Valor = pagamentoCurso.Total,
                NomeCartao = pagamentoCurso.NomeCartao,
                NumeroCartao = pagamentoCurso.NumeroCartao,
                ExpiracaoCartao = pagamentoCurso.ExpiracaoCartao,
                CvvCartao = pagamentoCurso.CvvCartao,
                CursoId = pagamentoCurso.CursoId
            };

            var transacao = _pagamentoCartaoCreditoFacade.RealizarPagamento(curso, pagamento);

            if (transacao.StatusTransacao == StatusTransacao.Pago)
            {
                pagamento.AdicionarEvento(new PagamentoRealizadoEvent(curso.Id, pagamentoCurso.AlunoId, transacao.PagamentoId, transacao.Id, curso.Valor));

                _pagamentoRepository.Adicionar(pagamento);
                _pagamentoRepository.AdicionarTransacao(transacao);

                await _pagamentoRepository.UnitOfWork.CommitAsync();
                return transacao;
            }

            await _mediatorHandler.PublicarNotificacao(new DomainNotification("pagamento", "A operadora recusou o pagamento"));
            await _mediatorHandler.PublicarEvento(new PagamentoRecusadoEvent(curso.Id, pagamentoCurso.AlunoId, transacao.PagamentoId, transacao.Id, curso.Valor));

            return transacao;
        }
    }
}
