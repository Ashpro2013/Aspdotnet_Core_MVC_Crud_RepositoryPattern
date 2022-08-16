using Microsoft.EntityFrameworkCore;

namespace AshproCrudTest.Models
{
    public class Repository<T> : IRepository<T> where T : class
    {
        private readonly AshproDBContext _dbContext;
        private DbSet<T> _dbSet;
        public Repository(AshproDBContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = dbContext.Set<T>();
        }
        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }
        public async Task<T> Get(int id)
        {
            return await _dbSet.FindAsync(id);
        }
        public async Task<int> Add(T entity)
        {
            int output = 0;
            _dbSet.Add(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }
        public async Task<int> Update(T entity)
        {
            int output = 0;
            _dbSet.Update(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }
        public async Task<int> Delete(T entity)
        {
            int output = 0;
            _dbSet.Remove(entity);
            output = await _dbContext.SaveChangesAsync();
            return output;
        }
    }
}
