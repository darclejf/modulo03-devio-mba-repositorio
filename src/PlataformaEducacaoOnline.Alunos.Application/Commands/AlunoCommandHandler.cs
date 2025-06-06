using MediatR;
using PlataformaEducacaoOnline.Alunos.Domain.Entities;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;
using PlataformaEducacaoOnline.Core.Communications.Mediator;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;

namespace PlataformaEducacaoOnline.Alunos.Application.Commands
{
    public class AlunoCommandHandler :
        IRequestHandler<NovoAlunoCommand, bool>,
        IRequestHandler<IniciarMatriculaCommand, bool>,
        IRequestHandler<IniciarAulaCommand, bool>
    {
        private readonly IAlunoRepository _alunoRepository;
        private readonly IMediatorHandler _mediatorHandler;

        public AlunoCommandHandler(IAlunoRepository alunoRepository, IMediatorHandler mediatorHandler)
        {
            _alunoRepository = alunoRepository;
            _mediatorHandler = mediatorHandler;
        }

        public async Task<bool> Handle(NovoAlunoCommand request, CancellationToken cancellationToken)
        {
            //if (!ValidarComando(request))
            //    return false;

            var aluno = Aluno.Create(
                                id: Guid.NewGuid(),
                                nome: request.Nome,
                                sobrenome: request.Sobrenome,
                                dataNascimento: request.DataNascimento,
                                email: request.Email);

            aluno.AdicionarEvento(new AlunoCriadoIntegrationEvent(aluno.Id, aluno.Email, request.Password, request.ConfirmPassword, aluno.NomeCompleto()));

            await _alunoRepository.InserirAsync(aluno);
            await _alunoRepository.UnitOfWork.CommitAsync();

            return true;
        }

        public async Task<bool> Handle(IniciarMatriculaCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorUserIdAsync(request.UserId);
            if (aluno == null)
                throw new NotImplementedException();
            aluno.CriarMatricula(request.CursoId);
            await _alunoRepository.UnitOfWork.CommitAsync();
            return true;    
        }

        public async Task<bool> Handle(IniciarAulaCommand request, CancellationToken cancellationToken)
        {
            var aluno = await _alunoRepository.ObterPorUserIdAsync(request.UserId);
            if (aluno == null)
                throw new NotImplementedException();
            aluno.IniciarAula(request.CursoId, request.AulaId);
            await _alunoRepository.UnitOfWork.CommitAsync();
            return true;

        }
    }
}
