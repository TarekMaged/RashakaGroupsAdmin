using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using X.PagedList;

namespace RashakaGroupsAdmin.Repository
{
    public interface IGenericRepository<TEntity> where TEntity : class
    {
        IQueryable<TEntity> GetAll();
        IQueryable<TEntity> GetAll(Expression<Func<TEntity, bool>> predicate);
        IPagedList<TEntity> GetAllByPage(int page, int size, Expression<Func<TEntity, int>> predicate,Expression<Func<TEntity, bool>> where);
        TEntity GetById(Func<TEntity, bool> predicate);
        TEntity Find(int id);

        void Add(TEntity entity);       
        void Delete(TEntity entity);
        void DeleteList(Expression<Func<TEntity, bool>> predicate);
        void Save();
       
       
    }
}
