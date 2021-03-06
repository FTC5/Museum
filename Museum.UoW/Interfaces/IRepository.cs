﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Museum.UoW.Interfaces
{
    public interface IRepository<T> : IDisposable where T : class
    {
        T Get(int id);
        IQueryable<T> Find(Func<T, Boolean> perdicate);
        IQueryable<T> GetAll();
        void Create(T item);
        void Update(T item);
        void Delete(int id);
    }
}
