using System.Linq.Expressions;

namespace NTierArchicture.Entites.Repository;

public interface IRepository<T>
{
    Task AddAsync(T entity, CancellationToken cancellationToken = default);
    void Update(T entity);
    void Remove(T entity);
    Task<T> GetByIdAsync(Expression<Func<T, bool>>expression, CancellationToken cancellationToken = default); //p=>p.name ==
    IQueryable<T> GetAll();
    IQueryable<T> GetWhere(Expression<Func<T, bool>> expression = default);
    Task<bool> AnyAsync(Expression<Func<T, bool>>expression, CancellationToken cancellationToken = default);

}
