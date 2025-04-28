using Microsoft.AspNetCore.Identity;
using PlataformaEducacaoOnline.Alunos.Domain.Validations;
using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Alunos.Domain.Entities
{
    public class Aluno : Entity, IAggregateRoot
    {
        public string? Nome { get; private set; }
        public string? Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }
        public DateTime DataCadastro { get; private set; }
        public string? Email { get; private set; }
        public bool Ativo { get; private set; }
        public Guid UserId { get; private set; }
        public IList<Matricula> Matriculas { get; private set; } = [];

        private Aluno() { }

        public static Aluno Create(Guid id, string nome, string sobrenome, DateTime dataNascimento, string email, Guid userId)
        {
            var aluno = new Aluno
            {
                Id = id,
                Ativo = true,
                DataCadastro = DateTime.Now,
                Email = email,
                DataNascimento = dataNascimento,                
                Nome = nome,
                Sobrenome = sobrenome,
                UserId = userId
            };            
            return aluno;
        }

        public override bool Valido()
        {
            ValidationResult = new AlunoValidations().Validate(this);
            return ValidationResult.IsValid;
        }

        public string NomeCompleto()
        {
            return $"{Nome} {Sobrenome}";
        }

        public void Ativar()
        {
            Ativo = true;
        }

        public void Desativar()
        {
            Ativo = false;
        }

        public void CriarMatricula(Guid cursoId, IList<Guid> aulasIds)
        {
            if (Matriculas.Any(x => x.CursoId == cursoId))
                throw new DomainException("Aluno já matriculado");

            Matriculas.Add(new Matricula(cursoId, aulasIds));
        }

        public void MarcarMatriculaPaga(Guid matriculaId)
        {
            throw new NotImplementedException();
        }

        public void MarcarMatriculaConcluida(Guid matriculaId)
        {
            throw new NotImplementedException();
        }

        public Matricula ObterMatriculaPorId(Guid id)
        {
            throw new NotImplementedException();
        }

        public void MarcarAulaConcluida(Guid matriculaId, Guid aulaId)
        {
            throw new NotImplementedException();
        }

        public void RemoverMatricula(Guid matriculaId)
        {
            throw new NotImplementedException();
        }
    }
}
