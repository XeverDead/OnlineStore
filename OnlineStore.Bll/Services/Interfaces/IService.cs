﻿using System.Collections.Generic;
using System.Threading.Tasks;

namespace OnlineStore.Bll.Services.Interfaces
{
    public interface IService<T>
    {
        public Task<IEnumerable<T>> GetAll();

        public Task<T> GetById(int id);

        public Task<T> Create(T entity);

        public Task<T> Update(T entity);

        public Task Delete(int id);
    }
}