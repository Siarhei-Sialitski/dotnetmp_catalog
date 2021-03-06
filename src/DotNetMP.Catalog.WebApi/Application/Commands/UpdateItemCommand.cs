using System.Runtime.Serialization;
using MediatR;

namespace DotNetMP.Catalog.WebApi.Application.Commands;

public class UpdateItemCommand : IRequest
{
    [DataMember]
    public Guid Id { get; private set; }

    [DataMember]
    public string Name { get; private set; } = null!;

    [DataMember]
    public string? Description { get; private set; }

    [DataMember]
    public string? Image { get; private set; }

    [DataMember]
    public decimal Price { get; private set; }

    [DataMember]
    public int Amount { get; private set; }

    [DataMember]
    public Guid CategoryId { get; private set; }

    public UpdateItemCommand(Guid id, Guid categoryId, string name, decimal price, int amount, string description, string image)
    {
        Id = id;
        Name = name;
        Price = price;
        Description = description;
        Image = image;
        Amount = amount;
        CategoryId = categoryId;
    }
}
