namespace Task4Linkerp.Models.Repositories
{
    public interface IRepository<TEntity> where TEntity : class
    {
        Task<IEnumerable<TEntity>> GetAllAsync();
        Task<TEntity?> GetByIdAsync(int id);
        Task<TEntity> CreateAsync(TEntity Item);
        Task<bool> UpdateAsync(TEntity Item);
        Task<bool> DeleteAsync(int id);
       
    }
}
