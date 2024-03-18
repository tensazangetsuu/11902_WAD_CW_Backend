namespace _11902_WAD_CW_backend.Repository
{
    public interface IBlogRepository<T>
    {
        Task<IEnumerable<T>> GetAll();
        Task<T> GetByID(int id);
        Task Add(T entity);
        Task Update(T entity);
        Task Delete(int id);
    }
}
