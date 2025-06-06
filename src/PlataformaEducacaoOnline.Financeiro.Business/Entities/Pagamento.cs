using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Financeiro.Business.Entities
{
    public class Pagamento : Entity, IAggregateRoot
    {
        public Guid CursoId { get; set; }
        public string Status { get; set; } = string.Empty;
        public decimal Valor { get; set; }
        public string NomeCartao { get; set; } = string.Empty;
        public string NumeroCartao { get; set; } = string.Empty;
        public string ExpiracaoCartao { get; set; } = string.Empty;
        public string CvvCartao { get; set; } = string.Empty;
        public Transacao? Transacao { get; set; }
    }
}
