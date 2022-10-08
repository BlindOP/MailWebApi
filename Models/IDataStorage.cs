namespace MailWebApi.Models
{
    /// <summary>
    /// Interface for implementing datastorage functional 
    /// </summary>
    public interface IDataStorage<T>
    {
        Task<IQueryable<T>> GetAllAsync();
        Task AddAsync(T item);
    }
}
