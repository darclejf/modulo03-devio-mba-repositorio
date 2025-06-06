using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Financeiro.Business.Entities
{
    public class Transacao : Entity
    {
        public Guid CursoId { get; set; }
        public Guid PagamentoId { get; set; }
        public decimal Total { get; set; }
        public StatusTransacao StatusTransacao { get; set; }
    }
}
