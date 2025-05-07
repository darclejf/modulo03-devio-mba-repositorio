using PlataformaEducacaoOnline.Alunos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaEducacaoOnline.Alunos.Domain.Tests
{
    public class AlunoMatriculaTests
    {
        [Fact(DisplayName = "Adicionar Nova Matrícula Válida")]

        public void AdicionarNovo_Valido()
        {
            // Arrange
            var aluno = Aluno.Create(
                Guid.NewGuid(),
                "Nome",
                "Sobrenome",
                DateTime.Now.AddYears(-30),
                "teste@teste.com");

            var cursoId = Guid.NewGuid();
            

            // Act
            var result = aluno.Valido();

            // Assert 
            Assert.True(result);
        }
    }
}
