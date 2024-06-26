﻿using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
[Authorize]
public class DinnersController(ISender mediator, IMapper mapper) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// Get dinner.
    /// </summary>
    /// <response code="200">Ok.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Unexpected error.</response>
    /// <returns><see cref="Task"/>OkObject.</returns>
    [HttpGet]
    public async Task<IActionResult> Get()
    {
        // var query = new GetDinnersQuery();
        //
        // var result = await _mediator.Send(query);
        //
        // var response = _mapper.Map<IEnumerable<DinnerResponse>>(result);
        await Task.CompletedTask;
        return Ok(Array.Empty<string>());
    }
}