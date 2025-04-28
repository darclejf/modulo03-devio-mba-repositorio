using PlataformaEducacaoOnline.Conteudos.Domain.Validations;
using PlataformaEducacaoOnline.Conteudos.Domain.ValueObjects;
using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Entities
{
    public class Aula : Entity
    {
        public string Titulo { get; private set; }
        public int Ordem {  get; private set; }
        public ConteudoProgramatico Conteudo { get; private set; }
        public Guid CursoId { get; private set; }
        public bool Ativo { get; private set; }

        private Aula() 
        {
            Titulo = "";
            Conteudo = new ConteudoProgramatico("", "", "", "");
        }

        internal Aula(Guid id, string titulo, int ordem, ConteudoProgramatico conteudo, Guid cursoId) 
        {
            Id = id;
            Titulo = titulo;
            Ordem = ordem;
            Conteudo = conteudo;
            CursoId = cursoId;
            Ativo = true;
        }

        public override bool Valido()
        {
            ValidationResult = new AulaValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        internal void Ativar()
        {
            Ativo = true;
        }

        internal void Desativar()
        {
            Ativo = false;
        }
    }
}
