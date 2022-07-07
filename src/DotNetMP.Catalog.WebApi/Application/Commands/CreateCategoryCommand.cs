using MediatR;
using System.Runtime.Serialization;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class CreateCategoryCommand : IRequest<Guid>
{
    [DataMember]
    public string Name { get; private set; } = null!;

    [DataMember]
    public string? Image { get; private set; }

    [DataMember]
    public Guid? ParentCategoryId { get; private set; }

    public CreateCategoryCommand(string name, string image, Guid? parentCategoryId = null)
    {
        Name = name;
        Image = image;
        ParentCategoryId = parentCategoryId;
    }
}
