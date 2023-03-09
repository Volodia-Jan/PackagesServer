using PackagesServer.Core.Enumerations;
using System.ComponentModel.DataAnnotations;

namespace PackagesServer.Core.Dtos;
public class PackageDto
{
    public int Id { get; set; }
    public string? PackageIdentifier { get; set; }   
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DeliverStatus Status { get; set; }
    public RecipientDto? Recipient { get; set; }
    public DateTime? LastUpdate { get; set; }
}
