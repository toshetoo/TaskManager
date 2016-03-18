using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;
using TaskManager.Models;

namespace TaskManager.Repositories
{
    public abstract class BaseRepository<T> where T:BaseModel, new()
    {
        public readonly DbContext context;
        public readonly DbSet<T> dbSet;

        public BaseRepository()
        {
            this.context = new AppContext();
            this.dbSet = this.context.Set<T>();
        }

        public T GetByID(int id)
        {
            return dbSet.Find(id);
        }

        public ICollection<T> GetAll()
        {
            return dbSet.ToList();
        }

        private void Insert(T item)
        {
            dbSet.Add(item);
            context.SaveChanges();
        }

        private void Update(T item)
        {
            context.Entry(item).State = EntityState.Modified;
            context.SaveChanges();
        }

        public void Save(T item)
        {
            if (item.ID == 0)
            {
                Insert(item);
            }
            else
            {
                Update(item);
            }
        }

        public void Delete(int id)
        {
            this.dbSet.Remove(GetByID(id));
            context.SaveChanges();
        }
    }
}