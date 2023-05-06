using System.ComponentModel.DataAnnotations;

namespace BARAZAIS.Data.Mappers;

public class RegistrationMapper
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

    [Required]
    public string? BussinesName { get; set; }

    [Required]
    [DataType(DataType.Text)]
    public string? Location { get; set; }

    public string? ImageUrl { get; set; }

    public string? NIDA { get; set; }

    public string? PhoneNumber { get; set; }

    public string? AccessLevel { get; set; }

    public RegistrationMapper() 
    {
        this.Email = null;
        this.FirstName = null;
        this.LastName = null;
        this.Password = null;
        this.ConfirmPassword = null;
        this.Location = null;
        this.BussinesName = null;
        this.AccessLevel = null;
        this.PhoneNumber = null;
        this.NIDA = null;
        this.ImageUrl = null;
    }
}
