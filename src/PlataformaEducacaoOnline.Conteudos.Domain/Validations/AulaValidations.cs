using FluentValidation;
using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Validations
{
    public class AulaValidations : AbstractValidator<Aula>
    {
        public AulaValidations() 
        {
            RuleFor(v => v.Id)
                    .NotEqual(Guid.Empty);

            RuleFor(v => v.Titulo)
                .NotEmpty().WithMessage("Informe Título válido");

            RuleFor(v => v.Ordem)
                .GreaterThan(v => 0)
                .WithMessage("Informe Ordem maior que Zero");

            RuleFor(v => v.Conteudo)
                .NotEmpty()
                .WithMessage("Informe Conteúdo Programático");

            RuleFor(v => v.Conteudo.Titulo)
                .NotEmpty()
                .WithMessage("Informe Título Conteúdo Programático");

            RuleFor(v => v.Conteudo.Descricao)
                .NotEmpty()
                .WithMessage("Informe Descrição Conteúdo Programático");

            RuleFor(v => v.Conteudo.Tipo)
                .NotEmpty()
                .WithMessage("Informe Tipo Conteúdo Programático");

            RuleFor(v => v.Conteudo.Url)
                .NotEmpty()
                .WithMessage("Informe Tipo Conteúdo Programático");

        }
    }
}
