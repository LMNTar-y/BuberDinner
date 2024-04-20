using BuberDinner.Application.Menus.Commands.CreateMenu;
using BuberDinner.Contracts.Menus;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("hosts/{hostId}/[controller]")]
[Authorize]
public class MenusController(ISender mediator, IMapper mapper) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// Create menu.
    /// </summary>
    /// <param name="hostId">HostId.</param>
    /// <param name="request">CreateMenuRequest.</param>
    /// <response code="200">Ok.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Unexpected error.</response>
    /// <returns><see cref="MenuResponse"/>MenuResponse.</returns>
    [HttpPost]
    [ProducesResponseType(typeof(MenuResponse), 200)]
    public async Task<IActionResult> CreateMenu(string hostId, CreateMenuRequest request)
    {
        var command = _mapper.Map<CreateMenuCommand>((request, hostId));
        var createMenuResult = await _mediator.Send(command);
        var result = _mapper.Map<MenuResponse>(createMenuResult);
        return Ok(result);
    }
}