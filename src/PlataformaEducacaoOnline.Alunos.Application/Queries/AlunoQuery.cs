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

        public async Task<IEnumerable<AlunoModel>> ObterTodos()
        {
            var alunos = await _alunoRepository.ObterTodosAsync();
            return alunos.Select(x => new AlunoModel
            {
                Id = x.Id,
                Nome = x.Nome,
                Ativo = x.Ativo,
                DataCadastro = x.DataCadastro,
                DataNascimento = x.DataNascimento,
                Email = x.Email,
                Sobrenome = x.Sobrenome,
                UserId = x.UserId,
            });
        }
    }
}
