namespace Entities.IRepositories
{
    public interface IUnitOfWork : IDisposable
    {
        IApplicationUserRepository ApplicationUser { get; }
        int Complete();
    }
}
