using PackagesServer.Core.Dtos;
using PackagesServer.Core.Enumerations;

namespace PackagesServer.Core.ServiceContracts;
public interface IPackagesService
{
    PackageDto CreatePackage(PackageAddRequest packageAddRequest);
    List<PackageDto> GetAllPackages();
    PackageDto GetPackageById(int id);
    PackageDto UpdatePackage(PackageDto packageDto);
    PackageDto DeletePackage(int id);
    List<PackageDto> GetAllPackagesByStatus(DeliverStatus status);
    List<PackageDto> GetAllPackagesByRecipientId(int recipientId);
    byte[] GetBareCode(int id);
}
