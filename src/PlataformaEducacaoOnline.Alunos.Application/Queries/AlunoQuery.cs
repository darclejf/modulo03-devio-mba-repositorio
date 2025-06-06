using PlataformaEducacaoOnline.Alunos.Application.Queries.Extensions;
using PlataformaEducacaoOnline.Alunos.Application.Queries.Model;
using PlataformaEducacaoOnline.Alunos.Domain.Repositories;

namespace PlataformaEducacaoOnline.Alunos.Application.Queries
{
    public class AlunoQuery : IAlunoQuery
    {
        private readonly IAlunoRepository _alunoRepository;

        public AlunoQuery(IAlunoRepository alunoRepository)
        {
            _alunoRepository = alunoRepository;
        }

        public async Task<AlunoModel> ObterPorUserIdAsync(Guid userId)
        {
            var aluno = await _alunoRepository.ObterPorUserIdAsync(userId);
            return aluno.ToModel();
        }

        public async Task<IEnumerable<AlunoModel>> ObterTodosAsync()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return alunos.Select(x => x.ToModel());
        }
    }
}
