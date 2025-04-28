using FluentValidation;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Validations
{
    public class CursoValidations : AbstractValidator<Curso>
    {
        public CursoValidations()
        {
            RuleFor(v => v.Id)
                .NotEqual(Guid.Empty);

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
