using RashakaGroupsAdmin.Models;
using RashakaGroupsAdmin.Repository.Interfaces;

namespace RashakaGroupsAdmin.Repository.UniteOfWork
{
    public class RashakaUniteOfWork : IRashakaUniteOfWork,IDisposable
    {
        private readonly RashakaContext db;
        public Dictionary<Type, object> repositories = new Dictionary<Type, object>();
        private bool disposed;
        public RashakaUniteOfWork()
        {
            db = new RashakaContext();
        }
        public void Dispose()
        {
            db.Dispose();
            GC.SuppressFinalize(this);
        }
        protected virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
            }
            this.disposed = true;
        }


        public IRashaka<TEntity> iRashaka<TEntity>() where TEntity : class
        {
            if (repositories.Keys.Contains(typeof(TEntity)) == true)
            {
                return repositories[typeof(TEntity)] as IRashaka<TEntity>;
            }
            IRashaka<TEntity> repo = new RashakaRepo<TEntity>(db);
            repositories.Add(typeof(TEntity), repo);
            return repo;
        }

        public void Save()
        {
            db.SaveChanges();
        }
    }
}