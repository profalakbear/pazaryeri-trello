namespace API.UoW
{
    public interface IUnitOfWork
    {
        Task<int> SaveChangesAsync();
    }
}
