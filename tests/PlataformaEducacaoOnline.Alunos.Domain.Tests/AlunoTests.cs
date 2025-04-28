using PlataformaEducacaoOnline.Alunos.Domain.Entities;

namespace PlataformaEducacaoOnline.Alunos.Domain.Tests
{    
    public class AlunoTests
    {
        [Fact(DisplayName = "Adicionar Novo Aluno Válido")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_Valido()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.True(result);
        }

        [Fact(DisplayName = "Adicionar Novo Aluno com Nome inválido")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_NomeInvalido()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "N",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, aluno.ValidationResult?.Errors.Count);
        }

        [Fact(DisplayName = "Adicionar Novo Aluno com Sobrenome inválido")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_SobrenomeInvalido()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "S",
                DateTime.Now.AddYears(-30),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, aluno.ValidationResult?.Errors.Count);
        }

        [Fact(DisplayName = "Adicionar Novo Aluno com Data Nascimento inválida")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_DataNascimentoInvalida()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                new DateTime(),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, aluno.ValidationResult?.Errors.Count);
        }

        [Fact(DisplayName = "Adicionar Novo Aluno com E-mail inválido")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_EmailInvalido()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste",
                Guid.NewGuid());

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, aluno.ValidationResult?.Errors.Count);
        }


        [Fact(DisplayName = "Adicionar Novo Aluno e Desativar")]
        [Trait("Alunos", "Alunos Testes")]

        public void AdicionarNovo_Desativar()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            aluno.Desativar();

            // Assert 
            Assert.False(aluno.Ativo);
        }

        [Fact(DisplayName = "Ativar aluno desativado")]
        [Trait("Alunos", "Alunos Testes")]

        public void Aluno_Ativar()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste@teste.com",
                Guid.NewGuid());

            // Act
            aluno.Desativar();

            // Assert 
            Assert.False(aluno.Ativo);
        }
    }
}
