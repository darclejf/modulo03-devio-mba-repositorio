using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Conteudos.Application.Commands
{
    public class AdicionarAulaCursoCommand : Command
    {
        public Guid CursoId { get; set; }
        public string Nome {  get; set; } = string.Empty;
        public string Titulo { get; set; } = string.Empty;
        public string Descricao { get; set; } = string.Empty;
        public string Tipo { get; set; } = string.Empty;
        public string Url { get; set; } = string.Empty;

        public AdicionarAulaCursoCommand(Guid cursoId, string nome, string titulo, string descricao, string tipo, string url)
        {
            CursoId = cursoId;
            Nome = nome;
            Titulo = titulo;
            Descricao = descricao;
            Tipo = tipo;
            Url = url;
        }

        public override bool Valido()
        {

            return true;   
        }
    }
}
