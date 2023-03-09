using System.ComponentModel.DataAnnotations;

namespace PackagesServer.Core.Dtos;
public class RecipientAddRequest
{
    [Required(ErrorMessage = "{0} cannot be blank")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "{0} cannot be blank")]
    public string? Address { get; set; }
}
