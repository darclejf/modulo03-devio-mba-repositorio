namespace PlataformaEducacaoOnline.Core.Data
{
    public interface IUnitOfWork
    {
        Task<bool> CommitAsync();
    }
}
