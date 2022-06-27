using DotNetMP.Catalog.WebApi.Application.Models;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Queries;

public class GetCategoriesQuery : IRequest<IList<CategoryRecord>>
{ }
