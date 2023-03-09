using PackagesServer.Core.Entities;
using PackagesServer.Core.RepositoryContracts;

namespace PackagesServer.Infrastructure.Repository;
public class RecipientsRepository : IRecipientsRepository
{
    private int _id;
    private List<Recipient> _recipients;

    public RecipientsRepository()
    {
        _id = 0;
        _recipients = new List<Recipient>()
        {
            new Recipient { Id = ++_id, Name = "John Doe", Address = "123 Main St" },
            new Recipient { Id = ++_id, Name = "Jane Smith", Address = "456 Oak St" },
            new Recipient { Id = ++_id, Name = "Bob Johnson", Address = "789 Maple St" },
            new Recipient { Id = ++_id, Name = "Samantha Lee", Address = "555 Pine St" },
            new Recipient { Id = ++_id, Name = "David Chen", Address = "999 Elm St" },
            new Recipient { Id = ++_id, Name = "Mary Kim", Address = "777 Cedar St" },
            new Recipient { Id = ++_id, Name = "Tom Baker", Address = "444 Walnut St" },
            new Recipient { Id = ++_id, Name = "Emily Davis", Address = "222 Spruce St" },
            new Recipient { Id = ++_id, Name = "Michael Brown", Address = "333 Birch St" },
            new Recipient { Id = ++_id, Name = "Lucy Wang", Address = "888 Ash St" }
        };
    }

    public bool DeleteById(int id)
    {
        var toRemove = _recipients.SingleOrDefault(x => x.Id == id);
        if (toRemove == null)
            return true;

        _recipients.Remove(toRemove);

        return !_recipients.Any(x => x.Id == id);
    }

    public List<Recipient> FindAllRecipients() => _recipients;

    public Recipient? FindById(int id) =>
        _recipients.FirstOrDefault(x => x.Id == id);

    public Recipient? Save(Recipient recipient)
    {
        if (_recipients.Any(x => x.Id == recipient.Id))
            return null;
        recipient.Id = ++_id;
        _recipients.Add(recipient);

        return recipient;
    }

    public Recipient? Update(Recipient recipient)
    {
        var toUpdate = FindById(recipient.Id);
        if (toUpdate == null) return null;
        toUpdate.Name = recipient.Name;
        toUpdate.Address = recipient.Address;

        return toUpdate;
    }
}
