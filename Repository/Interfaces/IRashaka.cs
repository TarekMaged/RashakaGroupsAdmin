using X.PagedList;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using System.Web;

namespace RashakaGroupsAdmin.Repository.Interfaces
{
    public interface IRashaka<T> where T : class
    {
        void Add(T entity);
        void AddRange(List<T> entities);
        void Delete(T entity);
        void DeleteList(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll();
        T GetByIncluding(Expression<Func<T, bool>> where, string includeProperties);
        int Count(Expression<Func<T, bool>> predicate);
        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate,bool AsNoTracking=true);
        IQueryable<T> GetAll(Expression<Func<T, bool>> where, string includeProperties, bool AsNoTracking = false);
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> orderBy, int page, int pageSize, string includeProperties, bool AsNoTracking = false);

        IQueryable<T> GetAll(Expression<Func<T, bool>> predicate, Expression<Func<T, int>> orderBy);
        IPagedList<T> GetAll( Expression<Func<T, int>> orderBy, int page, int pageSize);
        IPagedList<T> GetFoodsReport(Expression<Func<T, bool>> where, Expression<Func<T, int>> groupBy, Expression<Func<T, int>> orderBy, int page, int pageSize);
        IPagedList<T> GetAll(Expression<Func<T, bool>> where, Expression<Func<T, DateTime?>> orderBy, int page, int pageSize);
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> OrderBY, int page, int pageSize);
        IPagedList<T> SearchByStringWithPaging<TOrderBy>(Expression<Func<T, bool>> where,Expression<Func<T, TOrderBy>> ThenBY, int page, int pageSize);


        IPagedList<T> GetAllOrderByAscending<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> OrderByAscending, int page, int pageSize);
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, int page, int pageSize);
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, int>> orderBy2, int page, int pageSize);
        IPagedList<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy,Expression<Func<T, TOrderBy>> orderBy2, int page, int pageSize);
        IQueryable<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, bool>> orderBy, Expression<Func<T, TOrderBy>> orderBy2);
        IQueryable<T> GetAll<TOrderBy>(Expression<Func<T, bool>> where, Expression<Func<T, TOrderBy>> orderBy, Expression<Func<T, bool>> orderBy2);

        int Count<TOrderBy>(Expression<Func<T, bool>> where);



        T GetBy(Func<T, bool> predicate);
        T Find(int? id);
        void Save();
        T Update(T entity, int id);
        IPagedList<T> GetAllByPage(int page, int size, Expression<Func<T, int>> orderBy, Expression<Func<T, bool>> where);
        //void  AddRange(List<T> entity);
        //void DeleteRange(Expression<Func<T, bool>> where);
        //void Delete(Expression<Func<T, bool>> where);
        //void Delete(T t);
        //T GetBy(Expression<Func<T, bool>> where);
        //IPagedList<T> GetAllByPage(int page, int size, Expression<Func<T, int>> predicate, Expression<Func<T, bool>> where);

        //T Find(int id);
        //T Find(int? id);
        //Task<T> FindAsync(int id);
        //IQueryable<T> GetAll(Expression<Func<T, bool>> where);
        //IQueryable<T> GetAll();
        //void UpdateAccountImage(int? id, string image);
        //int? GetUserStepsCount(int accountId);
        //void SaveChanges();

    }
}