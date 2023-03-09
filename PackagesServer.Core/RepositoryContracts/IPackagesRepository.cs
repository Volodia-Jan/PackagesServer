using PackagesServer.Core.Entities;

namespace PackagesServer.Core.RepositoryContracts;
public interface IPackagesRepository
{
    Package? Save(Package package);
    List<Package> FindAll();
    Package? FindById(int id);
    Package? Update(Package package);
    bool DeleteById(int id);
}
