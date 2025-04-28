using Moq;
using PlataformaEducacaoOnline.Conteudos.Application.Commands;
using PlataformaEducacaoOnline.Conteudos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages.Notifications;

namespace PlataformaEducacaoOnline.Conteudos.Application.Tests
{
    public class AdicionarCursoTests
    {
        private CursoCommandHandler _cursoCommandHandler;
        private Mock<ICursoRepository> _cursoRepositoryMock;
        private Mock<IMediatorHandler> _mediatorHandlerMock;

        public AdicionarCursoTests()
        {
            _cursoRepositoryMock = new Mock<ICursoRepository>();
            _cursoRepositoryMock.Setup(r => r.UnitOfWork.CommitAsync()).Returns(Task.FromResult(true));

            _mediatorHandlerMock = new Mock<IMediatorHandler>();
            _cursoCommandHandler = new CursoCommandHandler(_cursoRepositoryMock.Object, _mediatorHandlerMock.Object);
        }

        [Fact]
        public async Task AdicionarCurso_CommandValido()
        {
            var command = new AdicionarCursoCommand("Curso", "Descrição Curso", DateTime.Now, DateTime.Now.AddDays(50));

            var result = await _cursoCommandHandler.Handle(command, CancellationToken.None);

            Assert.True(result);
            _cursoRepositoryMock.Verify(x => x.UnitOfWork.CommitAsync(), Times.Once);
        }

        [Fact]
        public async Task AdicionarCurso_CommandInvalido()
        {
            var command = new AdicionarCursoCommand("", "", DateTime.Now, DateTime.Now.AddDays(50));

            var result = await _cursoCommandHandler.Handle(command, CancellationToken.None);

            Assert.False(result);
            Assert.Equal(2, command.ValidationResult?.Errors.Count);
            _cursoRepositoryMock.Verify(x => x.UnitOfWork.CommitAsync(), Times.Never);
            _mediatorHandlerMock.Verify(x => x.PublicarNotificacao(It.IsAny<DomainNotification>()), Times.Exactly(2));
        }
    }
}