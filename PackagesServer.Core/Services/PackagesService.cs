using PackagesServer.Core.Dtos;
using PackagesServer.Core.Enumerations;
using PackagesServer.Core.Helpers;
using PackagesServer.Core.RepositoryContracts;
using PackagesServer.Core.ServiceContracts;

namespace PackagesServer.Core.Services;
public class PackagesService : IPackagesService
{
    private readonly IPackagesRepository _packagesRepository;
    private readonly IRecipientsRepository _recidientsRepository;
    private readonly MapperService _mapper;

    public PackagesService(IPackagesRepository packagesRepository, MapperService mapper, IRecipientsRepository recidientsRepository)
    {
        _packagesRepository = packagesRepository;
        _mapper = mapper;
        _recidientsRepository = recidientsRepository;
    }

    public PackageDto CreatePackage(PackageAddRequest packageAddRequest)
    {
        var recidient = packageAddRequest.Recipient ?? throw new ArgumentException("Recidient cannot be empty");
        if (_recidientsRepository.FindById(recidient.Id) == null)
            _recidientsRepository.Save(_mapper.ToEntity(recidient));
        var package = _packagesRepository.Save(_mapper.ToEntity(new PackageDto()
        {
            Name = packageAddRequest.Name,
            PackageIdentifier = packageAddRequest.PackageIdentifier,
            Description = packageAddRequest.Description,
            Recipient = packageAddRequest.Recipient,
            Status = DeliverStatus.Received,
            LastUpdate = DateTime.UtcNow
        }));

        return package == null
            ? throw new ArgumentException("Creating of pacakge object was unsuccessful")
            : _mapper.ToDto(package, _recidientsRepository);
    }

    public PackageDto DeletePackage(int id)
    {
        var package = _packagesRepository.FindById(id);

        return package == null
            ? throw new ArgumentException($"Package was not found by id:{id}")
            : _packagesRepository.DeleteById(id)
                ? _mapper.ToDto(package, _recidientsRepository)
                : throw new ArgumentException($"Package deleting was unsuccessful by id:{id}");
    }

    public List<PackageDto> GetAllPackages() =>
        _packagesRepository.FindAll()
        .Select(entity => _mapper.ToDto(entity, _recidientsRepository))
        .ToList();

    public List<PackageDto> GetAllPackagesByRecipientId(int recipientId) =>
        _packagesRepository.FindAll()
        .Where(e => e.RecipientId == recipientId)
        .Select(e => _mapper.ToDto(e, _recidientsRepository))
        .ToList();

    public List<PackageDto> GetAllPackagesByStatus(DeliverStatus status) =>
        _packagesRepository.FindAll()
        .Where(e => e.Status == status)
        .Select(e => _mapper.ToDto(e, _recidientsRepository))
        .ToList();

    public byte[] GetBareCode(int id)
    {
        var package = GetPackageById(id);

        return BarecodeGenerator.GenerateBarcode(package.PackageIdentifier);
    }

    public PackageDto GetPackageById(int id)
    {
        var package = _packagesRepository.FindById(id);
        return package == null 
            ? throw new ArgumentException($"User was not found by id:{id}") 
            : _mapper.ToDto(package, _recidientsRepository);
    }

    public PackageDto UpdatePackage(PackageDto packageDto)
    {
        var updated = _packagesRepository.Update(_mapper.ToEntity(packageDto));

        return updated == null
            ? throw new ArgumentException($"Package updating was unsuccessful by id:{packageDto.Id}")
            : _mapper.ToDto(updated, _recidientsRepository);
    }
}
