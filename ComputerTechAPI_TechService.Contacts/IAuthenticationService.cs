using ComputerTechAPI_DtoAndFeatures.DTO;
using Microsoft.AspNetCore.Identity;

namespace ComputerTechAPI_TechService.Contracts;

public interface IAuthenticationService
{
    Task<IdentityResult> RegisterUser(UserRegistrationDTO userRegistrationDTO);

    Task<bool> ValidateUser(UserAuthenticationDTO userAuthenticationDTO);
    Task<TokenDTO> CreateToken(bool populateExp);
    Task<TokenDTO> RefreshToken(TokenDTO tokenDTO);

}