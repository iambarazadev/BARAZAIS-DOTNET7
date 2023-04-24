using System.ComponentModel.DataAnnotations;

namespace BARAZAIS.Data.Mappers;

public class UserMapper
{
#nullable enable
    [Required]
    [EmailAddress]
    public string? Email { get; set; }

    [Required]
    public string? FirstName { get; set; }

    [Required]
    public string? LastName { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? Password { get; set; }

    [Required]
    [DataType(DataType.Password)]
    public string? ConfirmPassword { get; set; }

    public UserMapper() 
    {
        this.Email = null;
        this.FirstName = null;
        this.LastName = null;
        this.Password = null;
        this.ConfirmPassword = null;
    }
}
