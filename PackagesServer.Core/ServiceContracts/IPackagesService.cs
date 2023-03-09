using PackagesServer.Core.Dtos;

namespace PackagesServer.Core.ServiceContracts;
public interface IPackagesService
{
    PackageDto CreatePackage(PackageAddRequest packageAddRequest);
    List<PackageDto> GetAllPackages();
    PackageDto GetPackageById(int id);
    PackageDto UpdatePackage(PackageDto packageDto);
    PackageDto DeletePackage(int id);
}
