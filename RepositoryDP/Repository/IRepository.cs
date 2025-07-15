﻿namespace RepositoryDP.Repository
{
    public interface IRepository <T> where T : class
    {
        Task<T> CreateAsync (T entity);
        Task<T> UpdateAsync (T entity);
        Task DeleteAsync (int id);
        Task <IEnumerable<T>> GetAllAsync ();
        Task<T>GetByIdAsync(int id);

    }
}
