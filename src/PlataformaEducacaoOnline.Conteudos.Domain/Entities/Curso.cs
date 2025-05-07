using PlataformaEducacaoOnline.Conteudos.Domain.Validations;
using PlataformaEducacaoOnline.Conteudos.Domain.ValueObjects;
using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Entities
{
    public class Curso : Entity, IAggregateRoot
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataConclusao { get; private set; }

        public IList<Aula> Aulas { get; private set; } = [];

        public Curso(Guid id, string nome, string descricao, DateTime dataInicio, DateTime dataConclusao)
        {
            Id = id;
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataConclusao = dataConclusao;
            Aulas = [];
        }

        public override bool Valido()
        {
            ValidationResult = new CursoValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        public Aula AdicionarAula(string titulo, string tituloConteudo, string descricaoConteudo, string tipoConteudo, string urlConteudo)
        {
            var ordem = 0;
            if (Aulas.Any())
                ordem = Aulas.Max(a => a.Ordem);
            
            var aula = new Aula(Guid.NewGuid(), titulo, ++ordem, new ConteudoProgramatico(tituloConteudo, descricaoConteudo, tipoConteudo, urlConteudo), Id);
            if (aula.Valido())
                Aulas.Add(aula);
            return aula;
        }

        public void RemoverAula(Guid aulaId)
        {
            var aula = ObterAula(aulaId);
            Aulas.Remove(aula);
        }

        public void AtivarAula(Guid aulaId)
        {
            var aula = ObterAula(aulaId);
            aula.Ativar();
        }

        public void DesativarAula(Guid aulaId)
        {
            var aula = ObterAula(aulaId);
            aula.Desativar();
        }

        public Aula ObterAula(Guid aulaId)
        {
            var aula = Aulas.FirstOrDefault(x => x.Id == aulaId);
            if (aula == null)
                throw new DomainException("Aula não encontrada ou Id inválido.");
            return aula;
        }
    }
}
