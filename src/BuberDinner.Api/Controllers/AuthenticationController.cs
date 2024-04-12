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
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = _mapper.Map<RegisterCommand>(request);

        var result = await _mediator.Send(command);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = _mapper.Map<LoginQuery>(request);

        var result = await _mediator.Send(query);

        var response = _mapper.Map<AuthenticationResponse>(result);

        return Ok(response);
    }
}