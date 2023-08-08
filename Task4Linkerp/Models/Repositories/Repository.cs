using Microsoft.EntityFrameworkCore;
using Task4Linkerp.Models.Context;

namespace Task4Linkerp.Models.Repositories
{
    public class Repository<TEntity>:IRepository<TEntity> where TEntity : class
    {
        protected readonly DBContext _context;
        protected readonly DbSet<TEntity> _dbset;

        public Repository(DBContext context)
        {
            _context = context;
            _dbset = _context.Set<TEntity>();
        }
     
        public async Task<IEnumerable<TEntity>> GetAllAsync()
        {
            return await _dbset.ToListAsync();
        }
        public virtual async Task<TEntity?> GetByIdAsync(int id)
        {
            var re = await _dbset.FindAsync(id);
            return re;
        }
        public async Task<TEntity> CreateAsync(TEntity Item)
        {
            var item = (await _dbset.AddAsync(Item)).Entity;
            _context.SaveChanges();
            return item;
        }
        public Task<bool> UpdateAsync(TEntity Item)
        {
            var entity = _dbset.Update(Item);
            _context.SaveChanges();
            if (entity != null)
            {
                return Task.FromResult(true);
            }
            else
            {
                return Task.FromResult(false);
            }
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _dbset.Remove(item);
                _context.SaveChanges();
                return true;
            }
            else
            {
                return false;
            }

        }
 

       

      
    }
}
