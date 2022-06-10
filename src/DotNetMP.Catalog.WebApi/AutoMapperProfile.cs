using AutoMapper;
using DotNetMP.Catalog.Core.Aggregates.CategoryAggregate;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Add;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.Update;
using DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.ViewModels.Category;

namespace DotNetMP.Catalog.WebApi;

public class AutoMapperProfile : Profile
{
    public AutoMapperProfile()
    {
        CreateMap<CategoryViewModel, Category>();
        CreateMap<UpdateCategoryViewModel, Category>();        

        CreateMap<Category, ReadCategoryViewModel>();
        CreateMap<Category, GetCategoryByIdResponse>();
        CreateMap<Category, AddCategoryResponse>();
        CreateMap<Category, UpdateCategoryResponse>();
    }
}
