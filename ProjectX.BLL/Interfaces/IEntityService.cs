﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace ProjectX.BLL.Interfaces
{
    public interface IEntityService<T>
    {
        IEnumerable<T> GetAll();
        Task<IEnumerable<T>> GetAllAsync();
        T GetEntityById(int id);
        void Create(T entity);
        void Update(T entity);
        void Delete(int id);
        void Save();
    }
}
