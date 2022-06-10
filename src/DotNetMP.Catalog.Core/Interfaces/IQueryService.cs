namespace DotNetMP.Catalog.Core.Interfaces;

public interface IQueryService<T>
{
    public Task<T?> GetAsync(Guid tId, CancellationToken cancellationToken = default);
    public Task<IList<T>> GetListAsync(CancellationToken cancellationToken = default);
}
