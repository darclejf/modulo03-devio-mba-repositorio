namespace PlataformaEducacaoOnline.Conteudos.Domain.ValueObjects
{
    public class ConteudoProgramatico
    {
        public string Titulo { get; private set; }
        public string Descricao { get; private set; }
        public string Tipo { get; private set; } // Ex: "Artigo", "Video", "Exercício"
        public string Url { get; private set; }

        public ConteudoProgramatico(string titulo, string descricao, string tipo, string url)
        {
            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
            Url = url;
        }
    }
}
