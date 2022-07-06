using System.Net;
using DotNetMP.Catalog.WebApi.Application.Commands;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.Catalog.WebApi.Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Controllers;

[Route("api/[controller]")]
[ApiController]
public class ItemsController : ControllerBase
{
    private readonly IMediator _mediator;

    public ItemsController(IMediator mediator)
    {
        _mediator = mediator;
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(ItemRecord), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetItemById(Guid id, CancellationToken cancellationToken)
    {
        var queryResult = await _mediator.Send(new GetItemByIdQuery(id), cancellationToken);
        return Ok(queryResult);
    }

    [HttpGet]
    [ProducesResponseType(typeof(PaginatedItemViewModel<ItemRecord>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetItems([FromQuery] Guid? categoryId, CancellationToken cancellationToken, [FromQuery] int pageSize = 10, [FromQuery] int pageIndex = 0)
    {
        var queryResult = await _mediator.Send(new GetItemsQuery(categoryId, pageSize, pageIndex), cancellationToken);
        return Ok(queryResult);
    }

    [HttpPost]
    [ProducesResponseType((int)HttpStatusCode.Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateItem([FromBody] CreateItemCommand createItemCommand, CancellationToken cancellationToken)
    {
        var commandResult = await _mediator.Send(createItemCommand, cancellationToken);

        return CreatedAtAction(nameof(GetItemById), new { id = commandResult }, null);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateItem(Guid id, [FromBody] UpdateItemCommand updateItemCommand, CancellationToken cancellationToken)
    {
        if (id != updateItemCommand.Id)
        {
            return BadRequest();
        }
        await _mediator.Send(updateItemCommand, cancellationToken);

        return Ok();
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteItem(Guid id, CancellationToken cancellationToken)
    {
        var _ = await _mediator.Send(new DeleteItemCommand(id), cancellationToken);
        return NoContent();
    }
}
