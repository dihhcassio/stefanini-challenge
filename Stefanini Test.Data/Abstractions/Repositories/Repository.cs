using System.Data.Entity;

namespace Stefanini_Test.Data.Abstractions.Repositories
{
    public class Repository<TEntity> where TEntity : class
    {
        protected StefaniniDataContext _context;
        protected DbSet<TEntity> _dbSet;

        public Repository(StefaniniDataContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }
    }
}
