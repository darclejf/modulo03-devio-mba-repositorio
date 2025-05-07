using PlataformaEducacaoOnline.Core.Messages;

namespace PlataformaEducacaoOnline.Alunos.Application.Commands
{
    public class NovoAlunoCommand : Command
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public string Nome { get; private set; }
        public string Sobrenome { get; private set; }
        public DateTime DataNascimento { get; private set; }

        public NovoAlunoCommand(string email, string password, string confirmPassword, string nome, string sobrenome, DateTime dataNascimento)
        {
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Nome = nome;
            Sobrenome = sobrenome;
            DataNascimento = dataNascimento;
        }

        public override bool Valido()
        {
            return true;
        }
    }
}
