using PackagesServer.Core.Entities;

namespace PackagesServer.Core.RepositoryContracts;
public interface IRecipientsRepository
{
    Recipient? Save(Recipient recipient);
    List<Recipient> FindAllRecipients();
    Recipient? FindById(int id);
    Recipient? Update(Recipient recipient);
    bool DeleteById(int id);
}
