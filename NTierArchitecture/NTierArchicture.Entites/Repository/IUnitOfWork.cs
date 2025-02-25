namespace NTierArchicture.Entites.Repository;

public interface IUnitOfWork
{
   Task<int> SaveChangeAsync(CancellationToken cancellationToken = default);
}
