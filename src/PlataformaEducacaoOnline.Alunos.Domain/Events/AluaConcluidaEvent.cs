using PlataformaEducacaoOnline.Core.Messages.DomainEvents;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PlataformaEducacaoOnline.Alunos.Domain.Events
{
    public class AluaConcluidaEvent : DomainEvent
    {
        public AluaConcluidaEvent(Guid aggregateId) : base(aggregateId)
        {
        }
    }
}
