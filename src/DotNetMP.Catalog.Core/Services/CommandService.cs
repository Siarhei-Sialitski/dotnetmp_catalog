using DotNetMP.Catalog.Core.Interfaces;
using DotNetMP.SharedKernel.Exceptions;
using DotNetMP.SharedKernel.Interfaces;

namespace DotNetMP.Catalog.Core.Services;

internal class CommandService<T> : ICommandService<T>
    where T : class, IAggregateRoot
{
    private readonly IRepository<T> _repository;

    public CommandService(IRepository<T> repository)
    {
        _repository = repository;
    }

    public async Task<T> AddAsync(T t, CancellationToken cancellationToken = default)
    {
        return await _repository.AddAsync(t, cancellationToken);
    }

    public async Task DeleteAsync(Guid tId, CancellationToken cancellationToken = default)
    {
        var entity = await _repository.GetByIdAsync(tId);
        if (entity == null)
        {
            throw new NotFoundException("Category not found.");
        }

        await _repository.DeleteAsync(entity, cancellationToken);
    }

    public async Task UpdateAsync(T t, CancellationToken cancellationToken = default)
    {
        await _repository.UpdateAsync(t, cancellationToken);
    }
}
