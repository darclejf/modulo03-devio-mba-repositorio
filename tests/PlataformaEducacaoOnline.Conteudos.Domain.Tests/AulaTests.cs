using PlataformaEducacaoOnline.Conteudos.Domain.Entities;

namespace PlataformaEducacaoOnline.Conteudos.Domain.Tests
{
    public class AulaTests
    {
        [Fact(DisplayName = "Criar Nova Aula Válido")]
        public void AdicionarNovo_Valido()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "Nome",
                "Descricao",
                DateTime.Now,
                DateTime.Now.AddMonths(1));

            var aula = curso.AdicionarAula("Aula 01", "Título Conteúdo", "Descrição", "Vídeo", "http://teste.com");
            var aula2 = curso.AdicionarAula("Aula 02", "Título Conteúdo", "Descrição", "Vídeo", "http://teste.com");
            
            // Act
            var result = aula.Valido() && aula2.Valido();

            // Assert 
            Assert.True(result);
            Assert.Equal(2, curso.Aulas.Count());
        }

        [Fact(DisplayName = "Criar Nova Aula - Conteúdo Programático Inválido")]
        public void AdicionarNovo_ConteudoProgramaticoNulo()
        {
            // Arrange
            var curso = new Curso(
                Guid.NewGuid(),
                "Nome",
                "Descricao",
                DateTime.Now,
                DateTime.Now.AddMonths(1));

            var aula = curso.AdicionarAula("Aula 01", "", "", "", "");

            // Act
            var result = aula.Valido();

            // Assert 
            Assert.False(result);
            Assert.Equal(4, aula.ValidationResult?.Errors.Count);
        }
    }
}
