using AutoMapper;
using ComputerTechAPI_Contracts;
using ComputerTechAPI_DtoAndFeatures.DTO;
using ComputerTechAPI_Entities.ConfigurationModels;
using ComputerTechAPI_Entities.ErrorExceptions;
using ComputerTechAPI_Entities.Tech_Models;
using ComputerTechAPI_TechService.Contracts;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using System.Xml.Linq;

namespace ComputerTechAPI_Services;

internal sealed class AuthenticationService : IAuthenticationService
{
	private readonly ILogsManager _logger;
	private readonly IMapper _mapper;
	private readonly UserManager<User> _userManager;
	private readonly IOptions<JwtConfiguration> _configuration;
	private readonly JwtConfiguration _jwtConfiguration;

	private User? _user;

	public AuthenticationService(ILogsManager logger, IMapper mapper,
		UserManager<User> userManager, IOptions<JwtConfiguration> configuration)
	{
		_logger = logger;
		_mapper = mapper;
		_userManager = userManager;
		_configuration = configuration;
		_jwtConfiguration = _configuration.Value;
	}


    public async Task<IdentityResult> RegisterUser(UserRegistrationDTO userForRegistrationDTO)
    {
        var user = _mapper.Map<User>(userForRegistrationDTO);
        var result = await _userManager.CreateAsync(user,
        userForRegistrationDTO.Password);
        if (result.Succeeded)
            await _userManager.AddToRolesAsync(user, userForRegistrationDTO.Roles);
        return result;
    }


    public async Task<bool> ValidateUser(UserAuthenticationDTO userAuthenticationDTO)
    {
        _user = await _userManager.FindByNameAsync(userAuthenticationDTO.UserName);
        var result = (_user != null && await _userManager.CheckPasswordAsync(_user,
        userAuthenticationDTO.Password));
        if (!result)
            _logger.LogWarn($"{nameof(ValidateUser)}: Authentication failed. Invalid user name or password.");
        return result;
    }
    public async Task<TokenDTO> CreateToken(bool populateExp)
    {
        var signingCredentials = GetSigningCredentials();
        var claims = await GetClaims();
        var tokenOptions = GenerateTokenOptions(signingCredentials, claims);
        var refreshToken = GenerateRefreshToken();
        _user.RefreshToken = refreshToken;
        if (populateExp)
            _user.RefreshTokenExpiryTime = DateTime.Now.AddDays(7);
        await _userManager.UpdateAsync(_user);
        var accessToken = new JwtSecurityTokenHandler().WriteToken(tokenOptions);
        return new TokenDTO(accessToken, refreshToken);
    }
    private SigningCredentials GetSigningCredentials()
    {
        var key = Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("BONGOMAN"));
        var secret = new SymmetricSecurityKey(key);
        return new SigningCredentials(secret, SecurityAlgorithms.HmacSha256);
    }
    private async Task<List<Claim>> GetClaims()
    {
        var claims = new List<Claim>
          {
            new Claim(ClaimTypes.Name, _user.UserName)
          };
        var roles = await _userManager.GetRolesAsync(_user);
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }
        return claims;
    }
    private JwtSecurityToken GenerateTokenOptions(SigningCredentials signingCredentials, List<Claim> claims)
    {
        var tokenOptions = new JwtSecurityToken
        (
            issuer: _jwtConfiguration.ValidIssuer,
            audience: _jwtConfiguration.ValidAudience,
            claims: claims,
            expires: DateTime.Now.AddMinutes(Convert.ToDouble(_jwtConfiguration.Expires)),
            signingCredentials: signingCredentials
        );

        return tokenOptions;
    }

    private string GenerateRefreshToken()
    {
        var randomNumber = new byte[32];
        using (var randomNumberGenerator = RandomNumberGenerator.Create())
        {
            randomNumberGenerator.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);
        }
    }
    private ClaimsPrincipal GetPrincipalFromExpiredToken(string token)
    {
        var tokenValidationParameters = new TokenValidationParameters
        {
            ValidateAudience = true,
            ValidateIssuer = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(
            Encoding.UTF8.GetBytes(Environment.GetEnvironmentVariable("BONGOMAN"))),
            ValidateLifetime = true,
            ValidIssuer = _jwtConfiguration.ValidIssuer,
            ValidAudience = _jwtConfiguration.ValidAudience
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        SecurityToken securityToken;
        var principal = tokenHandler.ValidateToken(token, tokenValidationParameters, out securityToken);

        var jwtSecurityToken = securityToken as JwtSecurityToken;
        if (jwtSecurityToken == null || !jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256,
            StringComparison.InvariantCultureIgnoreCase))
        {
            throw new SecurityTokenException("Invalid token");
        }

        return principal;
    }


    public async Task<TokenDTO> RefreshToken(TokenDTO tokenDTO)
    {
        var principal = GetPrincipalFromExpiredToken(tokenDTO.AccessToken);
        var user = await _userManager.FindByNameAsync(principal.Identity.Name);
        if (user == null || user.RefreshToken != tokenDTO.RefreshToken ||
        user.RefreshTokenExpiryTime <= DateTime.Now)
            throw new RefreshTokenBadRequest();
        _user = user;
        return await CreateToken(populateExp: false);
    }

}