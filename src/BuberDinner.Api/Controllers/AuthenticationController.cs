using BuberDinner.Application.Authentication.Commands.Register;
using BuberDinner.Application.Authentication.Queries.Login;
using BuberDinner.Contracts.Authentication;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(ISender mediator) : ControllerBase
{
    private readonly ISender _mediator = mediator ?? throw new ArgumentNullException(nameof(mediator));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Register")]
    public async Task<IActionResult> Register(RegisterRequest request)
    {
        var command = new RegisterUserCommand(
            request.FirstName,
            request.LastName,
            request.Email,
            request.Password);

        var result = await _mediator.Send(command);

        var response = new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);

        return Ok(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Login")]
    public async Task<IActionResult> Login(LoginRequest request)
    {
        var query = new LoginQuery(
            request.Email,
            request.Password);

        var result = await _mediator.Send(query);

        var response = new AuthenticationResponse(
            result.User.Id,
            result.User.FirstName,
            result.User.LastName,
            result.User.Email,
            result.Token);

        return Ok(response);
    }
}