using PackagesServer.Core.Entities;
using PackagesServer.Core.Enumerations;
using PackagesServer.Core.RepositoryContracts;

namespace PackagesServer.Infrastructure.Repository;
public class PackagesRepository : IPackagesRepository
{
    private int _id;
    private readonly List<Package> _packages;

    public PackagesRepository()
    {
        _id = 0;
        _packages = new()
        {
            new Package { Id = ++_id, PackageIdentifier = "PKG001", Name = "Package 1", Description = "First package", Status = DeliverStatus.Received, RecipientId = 1, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG002", Name = "Package 2", Description = "Second package", Status = DeliverStatus.Delivered, RecipientId = 2, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG003", Name = "Package 3", Description = "Third package", Status = DeliverStatus.Received, RecipientId = 3, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG004", Name = "Package 4", Description = "Fourth package", Status = DeliverStatus.Delivered, RecipientId = 4, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG005", Name = "Package 5", Description = "Fifth package", Status = DeliverStatus.Received, RecipientId = 5, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG006", Name = "Package 6", Description = "Sixth package", Status = DeliverStatus.Received, RecipientId = 6, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG007", Name = "Package 7", Description = "Seventh package", Status = DeliverStatus.Delivered, RecipientId = 7, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG008", Name = "Package 8", Description = "Eighth package", Status = DeliverStatus.Received, RecipientId = 8, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG009", Name = "Package 9", Description = "Ninth package", Status = DeliverStatus.Delivered, RecipientId = 9, LastUpdate = DateTime.Now },
            new Package { Id = ++_id, PackageIdentifier = "PKG010", Name = "Package 10", Description = "Tenth package", Status = DeliverStatus.Received, RecipientId = 10, LastUpdate = DateTime.Now }

        };
    }
    public bool DeleteById(int id)
    {
        var countOfDeleted = _packages.RemoveAll(x => x.Id == id);

        return countOfDeleted > 0;
    }

    public List<Package> FindAll() => _packages;

    public Package? FindById(int id) =>
        _packages.FirstOrDefault(x => x.Id == id);

    public Package? Save(Package package)
    {
        if (_packages.Any(x => x.Id == package.Id))
            return null;
        package.Id = ++_id;
        _packages.Add(package);

        return package;
    }

    public Package? Update(Package package)
    {
        throw new NotImplementedException();
    }
}
