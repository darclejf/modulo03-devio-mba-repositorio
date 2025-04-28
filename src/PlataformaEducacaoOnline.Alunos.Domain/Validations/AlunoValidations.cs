using FluentValidation;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;

namespace PlataformaEducacaoOnline.Alunos.Domain.Validations
{
    public class AlunoValidations : AbstractValidator<Aluno>
    {
        public AlunoValidations()
        {
            RuleFor(c => c.Id)
                .NotEqual(Guid.Empty);

            RuleFor(c => c.UserId)
                .NotEmpty().WithMessage("Informe Usuário");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("Informe Nome válido")
                .Length(2, 150).WithMessage("O nome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.Sobrenome)
                .NotEmpty().WithMessage("Informe Sobrenome válido")
                .Length(2, 150).WithMessage("O Sobrenome deve ter entre 2 e 150 caracteres");

            RuleFor(c => c.DataNascimento)
                .NotEmpty()
                .WithMessage("Informe Data Nascimento válida");

            RuleFor(c => c.Email)
                .NotEmpty()
                .EmailAddress();
        }
    }
}
