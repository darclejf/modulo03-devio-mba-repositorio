namespace PlataformaEducacaoOnline.API.Models
{
    public class RealizarPagamentoRequest
    {
        public Guid CursoId { get; set; }
        public decimal Total { get; set; }
        public string NomeCartao { get; set; } = string.Empty;
        public string NumeroCartao { get; set; } = string.Empty;
        public string ExpiracaoCartao { get; set; } = string.Empty;
        public string CvvCartao { get; set; } = string.Empty;
    }
}
