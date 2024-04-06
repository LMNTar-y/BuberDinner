using BuberDinner.Application.Services.Authentication;
using BuberDinner.Contracts.Authentication;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class AuthenticationController(IAuthenticationService authenticationService) : ControllerBase
{
    private readonly IAuthenticationService _authenticationService = authenticationService ?? throw new ArgumentNullException(nameof(authenticationService));

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Register")]
    public IActionResult Register(RegisterRequest request)
    {
        var result = _authenticationService.Register(
            request.FirstName, 
            request.LastName, 
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }

    /// <summary>
    /// 
    /// </summary>
    /// <returns></returns>
    [HttpPost("Login")]
    public IActionResult Login(LoginRequest request)
    {
        var result = _authenticationService.Login(
            request.Email, 
            request.Password);

        var response = new AuthenticationResponse(
            result.Id,
            result.FirstName,
            result.LastName,
            result.Email,
            result.Token);

        return Ok(response);
    }

}