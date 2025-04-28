using PlataformaEducacaoOnline.Core.DomainObjects;

namespace PlataformaEducacaoOnline.Core.Data
{
    public interface IRepository<T> : IDisposable where T : IAggregateRoot
    {
        IUnitOfWork UnitOfWork { get; }
    }
}
