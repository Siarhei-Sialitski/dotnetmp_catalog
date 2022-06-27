using MediatR;
using System.Runtime.Serialization;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class UpdateCategoryCommand : IRequest
{
    [DataMember]
    public Guid Id { get; private set; }

    [DataMember]
    public string Name { get; private set; } = null!;

    [DataMember]
    public string? Image { get; private set; }

    [DataMember]
    public Guid? ParentCategoryId { get; private set; }

    public UpdateCategoryCommand(Guid id, string name, string image, Guid? parentCategoryId = null)
    {
        Id = id;
        Name = name;
        Image = image;
        ParentCategoryId = parentCategoryId;
    }
}
