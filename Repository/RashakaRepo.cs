using Microsoft.EntityFrameworkCore;
using RashakaGroupsAdmin.Repository.Interfaces;
using System.Linq.Expressions;
using X.PagedList;

namespace RashakaGroupsAdmin.Repository
{

    public class RashakaRepo<T> : IRashaka<T>, IDisposable where T : class
    {
        protected readonly DbContext dbContext;
        DbSet<T> dbSet;
        private bool disposed;
        public RashakaRepo(DbContext _dbContext)
        {
            dbContext = _dbContext;
            dbSet = dbContext.Set<T>();
        }
        public void Add(T entity)
        {
            dbSet.Add(entity);           
        }
        public void AddRange(List<T> entities)
        {
            dbSet.AddRange(entities);
        }
        public void Delete(T entity)
        {
            dbSet.Remove(entity);
        }

      
        public void DeleteList(Expression<Func<T, bool>> where)
        {
            var list = dbSet.Where(where);
            dbSet.RemoveRange(list);
        }
        public IQueryable<T> GetAll()
        {
            return dbSet;
        }
        public T GetByIncluding(Expression<Func<T, bool>> where, string includeProperties = null)
        {
            var item = dbSet.Where(where);
            if (includeProperties != null)
            {
                foreach (var includeProperty in includeProperties.Split(","))
                {
                    item = item.Include(includeProperty);
                }
            }
            return item.FirstOrDefault();
        }
        public IQueryable<T> GetAllIncluding(Expression<Func<T, bool>> where, Expression<Func<T, object>>[] includeProperties, bool AsNoTracking = false)
        {
            if (AsNoTracking)
            {
                return dbSet.AsNoTracking().Where(where);
            }
            return dbSet.Where(where);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> where, string includeProperties, bool AsNoTracking = false)
        {
            if (AsNoTracking)
            {
                return GetAllWithIncludedTable(dbSet.AsNoTracking().Where(where), includeProperties);
            }
            return GetAllWithIncludedTable(dbSet.Where(where), includeProperties);

        }

        public IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> orderBy, int page, int pageSize,
          string includeProperties, bool AsNoTracking = false)
        {
            if (AsNoTracking)
            {
                return GetAllWithIncludedTable(dbSet.AsNoTracking().Where(where), includeProperties).OrderByDescending(orderBy).ToPagedList(page, pageSize); ;
            }
            return GetAllWithIncludedTable(dbSet.Where(where), includeProperties).OrderByDescending(orderBy).ToPagedList(page, pageSize); ;
        }
        public IQueryable<T> GetAllWithIncludedTable(IQueryable<T> data, string includeProperties)
        {
            foreach (var item in includeProperties.Split(","))
            {
                data = data.Include(item);
            }
            return data;
        }
        public int Count(Expression<Func<T, bool>> predicate)
        {
            return dbSet.AsNoTracking().Where(predicate).Count();
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate,bool AsNoTracking)
        {
            if (AsNoTracking)
            {
                return dbSet.AsNoTracking().Where(predicate);
            }
            return dbSet.Where(predicate);
        }
        public IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy)
        {
            return dbSet.AsNoTracking().Where(predicate).OrderByDescending(orderBy);
        }
        public T GetBy(Func<T, bool> predicate)
        {
            return dbSet.Where(predicate).FirstOrDefault();
            //return dbContext.FirstOrDefault(predicate);
        }

        public T Find(int? id)
        {
            return dbSet.Find(Convert.ToInt32(id));
        }
        public void Save()
        {
            dbContext.SaveChanges();
        }
        public T Update(T entity, int id)
        {
            T current = Find(id);
            dbContext.Entry(current).CurrentValues.SetValues(entity);
            return current;
        }

        public IPagedList<T> GetAllByPage(int page, int size, Expression<Func<T, int>> orderBy, Expression<Func<T, bool>> where)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ToPagedList(page, size);
        }
        public IPagedList<T> GetAll(Expression<Func<T, int>> orderBy, int page, int pageSize)
        {
            return dbSet.AsNoTracking().OrderByDescending(orderBy).ToPagedList(page, pageSize);
        }
        public IPagedList<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, DateTime?>> orderBy, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ToPagedList(page, pageSize);
        }

        public IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> OrderByDescending, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(OrderByDescending).ToPagedList(page, pageSize);
        }
        public IPagedList<T> SearchByStringWithPaging<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> ThenBY, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderBy(ThenBY).ToPagedList(page, pageSize);
        }
        public IPagedList<T> GetAllOrderByAscending<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> OrderBy, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderBy(OrderBy).ToPagedList(page, pageSize);
        }
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, int>> orderBy2, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ThenByDescending(orderBy2).ToPagedList(page, pageSize);

        }

        public IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ToPagedList(page, pageSize);
        }
        public IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, TOrderBy>> orderBy2, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ThenByDescending(orderBy2).ToPagedList(page, pageSize);
        }
        public IQueryable<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, TOrderBy>> orderBy2)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ThenByDescending(orderBy2);
        }
        IQueryable<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> orderBy, Expression<Func<T, bool>> orderBy2)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ThenByDescending(orderBy2);
        }
        public int Count<TOrderBy>(Expression<Func<T, bool>> where)
        {
            return dbSet.AsNoTracking().Where(where).Count();
        }

        public IPagedList<T> GetFoodsReport(Expression<Func<T, bool>> where, Expression<Func<T, int>> groupBy, Expression<Func<T, int>> orderBy, int page, int pageSize)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(groupBy).ToPagedList(page, pageSize);
        }

        IPagedList<T> IRashaka<T>.GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, int>> orderBy2, int page, int pageSize)
        {
            throw new NotImplementedException();
        }

        IQueryable<T> IRashaka<T>.GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> orderBy, Expression<Func<T, bool>> orderBy2)
        {
            return dbSet.AsNoTracking().Where(where).OrderByDescending(orderBy).ThenByDescending(orderBy2);
        }

       
        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
            }
            this.disposed = true;
        }


        ///// <summary>
        ///// add any entity with any type
        ///// </summary>
        ///// <param name="entity"></param>
        //public T Add(T entity)
        //{
        //    dbSet.Add(entity);
        //    return entity;
        //}
        //public void AddRange(List<T> entities)
        //{
        //    dbSet.AddRange(entities);

        //}

        //public T GetBy(Expression<Func<T,bool>> where)
        //{
        //    return dbSet.FirstOrDefault(where);
        //}
        //public async Task<T> FindAsync(int id)
        //{
        //    return await dbSet.FindAsync(id);
        //}
        //public T Find(int id)
        //{
        //    return dbSet.Find(id);
        //}
        //public T Find(int? id)
        //{
        //    return dbSet.Find(Convert.ToInt32( id));
        //}

        //public void SaveChanges()
        //{
        //    dbContext.SaveChanges();
        //}


        //public IQueryable<T> GetAll(Expression<Func<T,bool>> where)
        //{
        //    return dbSet.Where(where);
        //}
        //public IQueryable<T> GetAll()
        //{
        //    return dbSet;
        //}
        //public void SaveUserOrder(int? accountId, string period, string type, int? order)
        //{
        //    dbContext.SaveUserOrder(accountId, period, type, order);
        //}

        //public void UpdateAccountImage(int? id, string image)
        //{
        //    dbContext.UpdateAccountImage(id, image);
        //}

        //public void DeleteRange(Expression<Func<T,bool>> where)
        //{

        //  var list=  dbSet.Where(where);
        //    dbSet.RemoveRange(list);
        //}
        //public void Delete(Expression<Func<T,bool>> where)
        //{
        //    dbSet.Remove(dbSet.Where(where).FirstOrDefault());
        //}
        //public void Delete(T t)
        //{
        //    dbSet.Remove(t);
        //}



    }
}