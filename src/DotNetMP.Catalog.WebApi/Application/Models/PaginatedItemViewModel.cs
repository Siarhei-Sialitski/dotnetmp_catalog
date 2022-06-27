namespace DotNetMP.Catalog.WebApi.Application.Models;

public class PaginatedItemViewModel<TEntity> where TEntity : class
{
    public int PageIndex { get; private set; }
    public int PageSize { get; private set; }
    public long TotalCount { get; private set; }
    public IList<TEntity> Data { get; private set; }

    public PaginatedItemViewModel(int pageIndex, int pageSize, long totalCount, IList<TEntity> data)
    {
        PageIndex = pageIndex;
        PageSize = pageSize;
        TotalCount = totalCount;
        Data = data;
    }
}
