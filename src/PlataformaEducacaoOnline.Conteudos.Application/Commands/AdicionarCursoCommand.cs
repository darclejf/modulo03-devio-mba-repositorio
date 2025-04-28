using FluentValidation;
using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Conteudos.Application.Commands
{
    public class AdicionarCursoCommand : Command
    {
        public string Nome { get; private set; }
        public string Descricao { get; private set; }
        public DateTime DataInicio { get; private set; }
        public DateTime DataConclusao { get; private set; }

        public AdicionarCursoCommand(string nome, string descricao, DateTime dataInicio, DateTime dataConclusao)
        {
            Nome = nome;
            Descricao = descricao;
            DataInicio = dataInicio;
            DataConclusao = dataConclusao;
        }

        public override bool Valido()
        {
            ValidationResult = new AdicionarCursoValidations().Validate(this);
            return ValidationResult.IsValid;
        }
    }

    public class AdicionarCursoValidations : AbstractValidator<AdicionarCursoCommand>
    {
        public AdicionarCursoValidations()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("Informe Nome válido")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(v => v.DataInicio)
                .NotEqual(new DateTime())
                .WithMessage("Informe Data Início válida");

            RuleFor(v => v.DataConclusao)
                .NotEmpty()
                .WithMessage("Informe Data Conclusão válida");

            RuleFor(v => v.DataConclusao)
                .GreaterThanOrEqualTo(v => v.DataInicio)
                .WithMessage("Informe Data de Conclusão não deve ser maior que Data de Início");
        }
    }
}
