using PackagesServer.Core.Dtos;
using PackagesServer.Core.Entities;
using PackagesServer.Core.RepositoryContracts;
using PackagesServer.Core.ServiceContracts;

namespace PackagesServer.Core.Services;
public class MapperService
{
    public MapperService()
    {
    }

    public Recipient ToEntity(RecipientDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        Address = dto.Address,
    };

    public RecipientDto ToDto(Recipient entity) => new()
    {
        Id = entity.Id,
        Name = entity.Name,
        Address = entity.Address,
    };

    public Package ToEntity(PackageDto dto) => new()
    {
        Id = dto.Id,
        Name = dto.Name,
        PackageIdentifier = dto.PackageIdentifier,
        Description = dto.Description,
        Status = dto.Status,
        LastUpdate = dto.LastUpdate,
        RecipientId = dto.Recipient.Id
    };

    public PackageDto ToDto(Package entity, IRecipientsRepository recipientRepository)
    {
        var recipient = recipientRepository.FindById(entity.RecipientId);
        if (recipient == null)
            throw new ArgumentException($"Recipient was not found by id:{entity.RecipientId}");

        return new()
        {
            Id = entity.Id,
            Name = entity.Name,
            PackageIdentifier = entity.PackageIdentifier,
            Description = entity.Description,
            Status = entity.Status,
            LastUpdate = entity.LastUpdate,
            Recipient = ToDto(recipient)
        };
    }
}
