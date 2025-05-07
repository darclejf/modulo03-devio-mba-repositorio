using MediatR;
using PlataformaEducacaoOnline.Autenticacao.Interfaces;
using PlataformaEducacaoOnline.Autenticacao.Models;
using PlataformaEducacaoOnline.Core.Constants;
using PlataformaEducacaoOnline.Core.Messages.IntegrationEvents;

namespace PlataformaEducacaoOnline.Autenticacao.Events
{
    public class AutenticacaoEventHandler : INotificationHandler<AlunoCriadoIntegrationEvent>
    {
        private readonly IAutenticacaoServices _autenticacaoServices;

        public AutenticacaoEventHandler(IAutenticacaoServices autenticacaoServices)
        {
            _autenticacaoServices = autenticacaoServices;
        }

        public async Task Handle(AlunoCriadoIntegrationEvent notification, CancellationToken cancellationToken)
        {
            var model = new RegisterUserModel
            {
                ConfirmPassword = notification.ConfirmPassword,
                Email = notification.Email,
                Name = notification.Name,
                Password = notification.Password,
                Role = Roles.ALUNOROLE,
                EntityId = notification.AggregateId
            };
            var resultado = await _autenticacaoServices.RegisterAsync(model);

        }
    }
}
