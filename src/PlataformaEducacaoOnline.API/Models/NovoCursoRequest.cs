namespace PlataformaEducacaoOnline.API.Models
{
    public class NovoCursoRequest
    {
        public string Nome { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public DateTime DataInicio { get; set; }
        public DateTime DataConclusao { get; set; }
    }
}
