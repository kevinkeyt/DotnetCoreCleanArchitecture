
using CleanArchitecture.Domain.Common.Interfaces;

namespace CleanArchitecture.Application.Interfaces;

public interface IGenericRepository<T> where T : class, IEntity
{
    IQueryable<T> Entities {get;}

    Task<T> GetByIdAsync(int id);
    Task<List<T>> GetAllAsync();
    Task<T> AddAsync(T entity);
    Task<T> UpdateAsync(T entity);
    Task<T> DeleteAsync(T entity);
}