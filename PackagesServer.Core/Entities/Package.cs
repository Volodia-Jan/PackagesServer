using PackagesServer.Core.Enumerations;

namespace PackagesServer.Core.Entities;
public class Package
{
    public int Id { get; set; }
    public string? PackageIdentifier { get; set; }
    public string? Name { get; set; }
    public string? Description { get; set; }
    public DeliverStatus Status { get; set; }
    public int RecipientId { get; set;}
    public DateTime? LastUpdate { get; set; }
}
