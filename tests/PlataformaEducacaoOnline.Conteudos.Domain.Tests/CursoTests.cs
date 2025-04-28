using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Tests
{
    public class CursoTests
    {
        [Fact(DisplayName = "Criar Novo Curso Válido")]        
        public void AdicionarNovo_Valido()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "Nome",
                "Descricao",
                DateTime.Now,
                DateTime.Now.AddMonths(1));

            // Act
            var result = curso.Valido();

            // Assert 
            Assert.True(result);
        }

        [Fact(DisplayName = "Criar Novo Curso Data Conclusão menor que Data Inicial")]
        public void AdicionarNovo_DataConclusaoInvalida()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "Nome",
                "Descricao",
                DateTime.Now.AddDays(1),
                DateTime.Now);

            // Act
            var result = curso.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, curso.ValidationResult?.Errors.Count);
        }

        [Fact(DisplayName = "Criar Novo Curso Data Inclusão inválida")]
        public void AdicionarNovo_DataInclusaoInvalida()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "Nome",
                "Descricao",
                new DateTime(),
                DateTime.Now);

            // Act
            var result = curso.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(1, curso.ValidationResult?.Errors.Count);
        }

        [Fact(DisplayName = "Criar Novo Curso Nome inválido")]
        public void AdicionarNovo_NomeInvalido()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "",
                "",
                DateTime.Now,
                DateTime.Now.AddDays(1));

            // Act
            var result = curso.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(2, curso.ValidationResult?.Errors.Count);
        }
    }
}