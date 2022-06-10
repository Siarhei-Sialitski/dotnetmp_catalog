using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Services;

internal class QueryService<T> : IQueryService<T>
    where T : class, IAggregateRoot
{
    private readonly IRepository<T> _repository;

    public QueryService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T?> GetAsync(Guid tId, CancellationToken cancellationToken = default)
    {
        return await _repository.GetByIdAsync(tId, cancellationToken);
    }

    public async Task<IList<T>> GetListAsync(CancellationToken cancellationToken = default)
    {
        return await _repository.ListAsync(cancellationToken);
    }
}
