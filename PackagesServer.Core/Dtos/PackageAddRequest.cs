using PackagesServer.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PackagesServer.Core.Dtos;
public class PackageAddRequest
{
    [Required(ErrorMessage = "{0} cannot be blank!")]
    public string? PackageIdentifier { get; set; }
    [Required(ErrorMessage = "{0} cannot be blank!")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "{0} cannot be blank!")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "{0} cannot be blank!")]
    public RecipientDto? Recipient { get; set; }
}
