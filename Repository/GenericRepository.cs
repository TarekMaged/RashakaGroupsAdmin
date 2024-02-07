using RashakaGroupsAdmin.Models;
using System.Linq.Expressions;
using X.PagedList;

namespace RashakaGroupsAdmin.Repository
{
    public class GenericRepository<TEntity> : IGenericRepository<TEntity> where TEntity : class
    {
        private readonly RashakaContext _db;

        public GenericRepository()
        {
            _db = new RashakaContext();
        }

        public void Add(TEntity entity)
        {
            _db.Set<TEntity>().Add(entity);
        }
        //public void AddRange(List<TEntity> entities)
        //{
        //    _db.Set<TEntity>().AddRange(entities);
        //}
        public void Delete(TEntity entity)
        {
            _db.Set<TEntity>().Remove(entity);
        }

        //public void DeleteList(Expression<Func<TEntity, bool>> predicate)
        //{
        //    var dbSet = _db.Set<TEntity>();
        //    dbSet.RemoveRange(dbSet.Where(predicate));
        //}    
    
        public IQueryable<TEntity> GetAll()
        {
            return _db.Set<TEntity>();
        }

        public IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate)
        {
            return _db.Set<TEntity>().Where(predicate);
        }
      
        public TEntity GetById(Func<TEntity, bool> predicate)
        {
            return _db.Set<TEntity>().FirstOrDefault(predicate);
        }

        public TEntity Find(int id)
        {
            return _db.Set<TEntity>().Find(id);
        }
        public void Save()
        {
            _db.SaveChanges();
        }
        public TEntity Update(TEntity entity,int id)
        {
            TEntity current = Find(id);
            _db.Entry(current).CurrentValues.SetValues(entity);
            return current;
        }

        public IPagedList<TEntity> GetAllByPage(int page, int size, Expression<Func<TEntity, int>> predicate,Expression<Func<TEntity, bool>> where)
        {
            return _db.Set<TEntity>().Where(where).OrderByDescending(predicate).ToPagedList(page,size);
        }

        public void DeleteList(Expression<Func<TEntity, bool>> predicate)
        {
            throw new NotImplementedException();
        }
    }
}