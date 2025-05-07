namespace PlataformaEducacaoOnline.Core.Messages.IntegrationEvents
{
    public class AlunoCriadoIntegrationEvent : IntegrationEvent
    {
        public string Email { get; private set; }
        public string Password { get; private set; }
        public string ConfirmPassword { get; private set; }
        public string Name { get; private set; }

        public AlunoCriadoIntegrationEvent(Guid aggregateId, string email, string password, string confirmPassword, string name)
        {
            AggregateId = aggregateId;
            Email = email;
            Password = password;
            ConfirmPassword = confirmPassword;
            Name = name;
        }
    }
}
