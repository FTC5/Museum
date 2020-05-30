using Museum.DAL.Context;
using Museum.UoW.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.UoW.EFCodeFirst
{
    class Repository<T> : IRepository<T> where T : class 
    {
        private MuseumContext db = null;
        private DbSet<T> table = null;
        public Repository(string connectionString)
        {
            this.db = new MuseumContext(connectionString);
            table = db.Set<T>();
        }
        public Repository(MuseumContext db)
        {
            this.db = db;
            table = db.Set<T>();
        }
        public void Create(T item)
        {
            this.table.Add(item);
        }

        public void Delete(int id)
        {
            T type = table.Find(id);
            if (type != null)
                table.Remove(type);
        }

        public IQueryable<T> Find(Func<T, bool> perdicate)
        {
            return table.Where(perdicate).AsQueryable();
        }

        public T Get(int id)
        {
            return table.Find(id);
        }

        public IQueryable<T> GetAll()
        {
            return table;
        }

        public void Update(T item)
        {
            db.Entry(item).State = EntityState.Modified;
        }
        private bool disposed = false;

        internal virtual void Dispose(bool disposing)
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

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
