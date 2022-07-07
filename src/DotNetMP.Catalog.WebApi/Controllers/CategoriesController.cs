using System.Net;
using DotNetMP.Catalog.WebApi.Application.Commands;
using DotNetMP.Catalog.WebApi.Application.Models;
using DotNetMP.Catalog.WebApi.Application.Queries;
using DotNetMP.Catalog.WebApi.Hateos;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace DotNetMP.Catalog.WebApi.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoriesController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly LinkGenerator _linkGenerator;

    public CategoriesController(
        IMediator mediator,
        LinkGenerator linkGenerator)
    {
        _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
        _linkGenerator = linkGenerator;
    }

    [HttpGet]
    [ProducesResponseType(typeof(IEnumerable<CategoryRecord>), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<ActionResult<IEnumerable<CategoryRecord>>> GetCategories(CancellationToken cancellationToken)
    {
        var commandResult = await _mediator.Send(new GetCategoriesQuery(), cancellationToken);

        var hateosResult = new List<HateosCategoryRecord>();
        foreach (var category in commandResult)
        {
            var categoryLinks = CreateLinksForCategory(category.id);

            hateosResult.Add(new HateosCategoryRecord(category.id, category.name, category.image, category.parentCategoryId, categoryLinks.ToList()));
        }

        return Ok(hateosResult);
    }

    [HttpGet]
    [Route("{id:guid}")]
    [ProducesResponseType(typeof(CategoryRecord), (int)HttpStatusCode.OK)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> GetCategoryById(Guid id, CancellationToken cancellationToken)
    {
        var queryResult = await _mediator.Send(new GetCategoryByIdQuery(id), cancellationToken);
        var categoryLinks = CreateLinksForCategory(queryResult.id);
        var hateosResponse = new HateosCategoryRecord(queryResult.id, queryResult.name, queryResult.image, queryResult.parentCategoryId, categoryLinks.ToList());
        return Ok(hateosResponse);
    }

    [HttpDelete]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> DeleteCategory(Guid id, CancellationToken cancellationToken)
    {
        var _ = await _mediator.Send(new DeleteCategoryCommand(id), cancellationToken);
        return NoContent();
    }

    [HttpPost]
    [ProducesResponseType(StatusCodes.Status201Created)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> CreateCategory([FromBody] CreateCategoryCommand createCategoryCommand, CancellationToken cancellationToken)
    {
        var commandResult = await _mediator.Send(createCategoryCommand, cancellationToken);

        return CreatedAtAction(nameof(GetCategoryById), new { id = commandResult }, null);
    }

    [HttpPut]
    [Route("{id}")]
    [ProducesResponseType((int)HttpStatusCode.NoContent)]
    [ProducesResponseType((int)HttpStatusCode.NotFound)]
    [ProducesResponseType((int)HttpStatusCode.BadRequest)]
    public async Task<IActionResult> UpdateCategory(Guid id, [FromBody] UpdateCategoryCommand updateCategoryCommand, CancellationToken cancellationToken)
    {
        if (id != updateCategoryCommand.Id)
        {
            return BadRequest();
        }

        await _mediator.Send(updateCategoryCommand, cancellationToken);

        return NoContent();
    }

    private IEnumerable<Link> CreateLinksForCategory(Guid id)
    {
        var links = new List<Link>
        {
            new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(GetCategoryById), values: new { id })!,
            "self",
            "GET"),

            new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(DeleteCategory), values: new { id })!,
            "delete_category",
            "DELETE"),

            new Link(_linkGenerator.GetUriByAction(HttpContext, nameof(UpdateCategory), values: new { id })!,
            "update_category",
            "PUT")
        };

        return links;
    }
}
