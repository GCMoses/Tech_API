using System.ComponentModel.DataAnnotations;

namespace ComputerTechAPI_DtoAndFeatures.DTO;

public record UserRegistrationDTO
{
    public string? FirstName { get; init; }
    public string? LastName { get; init; }
    [Required(ErrorMessage = "Username is required")]
    public string? UserName { get; init; }
    [Required(ErrorMessage = "Password is required")]
    public string? Password { get; init; }

    [DataType(DataType.EmailAddress)]
    public string? Email { get; init; }

    [DataType(DataType.PhoneNumber)]
    public string? PhoneNumber { get; init; }
    public ICollection<string>? Roles { get; init; }
}
