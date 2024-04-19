using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MapsterMapper;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
[AllowAnonymous]
public class AuthenticationController(ISender mediator, IMapper mapper) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));
    private readonly IMapper _mapper = mapper ?? throw new ArgumentNullException(nameof(mapper));

    /// <summary>
    /// Register Request.
    /// </summary>
    /// <param name="request">RegisterRequest.</param>
    /// <response code="200">Ok. Token.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Unexpected error.</response>
    /// <returns><see cref="AuthenticationResponse"/> AuthenticationResponse.</returns>
    [ProducesResponseType(typeof(AuthenticationResponse), 200)]
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var result = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }

    /// <summary>
    /// Login Request.
    /// </summary>
    /// <param name="request">LoginRequest.</param>
    /// <response code="200">Ok. Token.</response>
    /// <response code="400">Bad request.</response>
    /// <response code="500">Unexpected error.</response>
    /// <returns><see cref="AuthenticationResponse"/> AuthenticationResponse.</returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }
}