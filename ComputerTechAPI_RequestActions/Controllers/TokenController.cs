using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_RequestActions.FilteringActions;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Mvc;

namespace ComputerTechAPI_RequestActions.Controllers;

[Route("api/token")]
[ApiController]
public class TokenController : ControllerBase
{
    private readonly IServiceManager _service;

    public TokenController(IServiceManager service) => _service = service;

    [HttpPost("refresh")]
    [ServiceFilter(typeof(ValidationFilterAttribute))]
    public async Task<IActionResult> Refresh([FromBody] TokenDTO tokenDTO)
    {
        var tokenDTOToReturn = await _service.AuthenticationService.RefreshToken(tokenDTO);

        return Ok(tokenDTOToReturn);
    }
}
