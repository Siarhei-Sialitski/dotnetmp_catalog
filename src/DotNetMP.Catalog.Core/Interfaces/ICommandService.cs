namespace DotNetMP.Catalog.Core.Interfaces;

public interface ICommandService<T>
{
    public Task<T> AddAsync(T t, CancellationToken cancellationToken = default);
    public Task UpdateAsync(T t, CancellationToken cancellationToken = default);
    public Task DeleteAsync(Guid TId, CancellationToken cancellationToken = default);
}
