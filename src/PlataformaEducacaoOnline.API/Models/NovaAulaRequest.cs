namespace PlataformaEducacaoOnline.API.Models
{
    public class NovaAulaRequest
    {
        public Guid CursoId { get; set; }
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;
    }
}
