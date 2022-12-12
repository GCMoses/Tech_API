using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/authentication")]
[ApiController]
public class AuthenticationController : ControllerBase
{
    private readonly IServiceManager _service;
    public AuthenticationController(IServiceManager service) => _service = service;

    /// <summary>
    /// User Registrer 
    /// </summary>
    /// <param name="userRegistrationDTO"></param>
    /// <returns>A user is Registered, Access Token and Refresh Token</returns>
    /// <response code="201">User is registered</response>
    /// <response code="400">If the user is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> RegisterUser([FromBody] UserRegistrationDTO userRegistrationDTO)
    {
        var result = await
        _service.AuthenticationService.RegisterUser(userRegistrationDTO);
        if (!result.Succeeded)
        {
            foreach (var error in result.Errors)
            {
                ModelState.TryAddModelError(error.Code, error.Description);
            }
            return BadRequest(ModelState);
        }
        return StatusCode(201);
    }

    /// <summary>
    /// User Login 
    /// </summary>
    /// <param name="user"></param>
    /// <returns>A user is Authenticated, Access Token and Refresh Token</returns>
    /// <response code="200">Log in user</response>
    /// <response code="400">If the user is null</response>
    /// <response code="422">If the model is invalid</response>
    [HttpPost("login")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Authenticate([FromBody] UserAuthenticationDTO user)
    {
        if (!await _service.AuthenticationService.ValidateUser(user))
        return Unauthorized();
        var tokenDTO = await _service.AuthenticationService
        .CreateToken(populateExp: true);
        return Ok(tokenDTO);
    }
} 

