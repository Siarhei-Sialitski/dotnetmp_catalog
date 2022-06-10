﻿using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace DotNetMP.Catalog.WebApi.Endpoints.CategoryEndpoints.GetById;

public class DeleteCategoryRequest
{
    public const string Route = "/Categories/{CategoryId:guid}";

    [Required]
    [FromRoute]
    public Guid CategoryId { get; set; }
}