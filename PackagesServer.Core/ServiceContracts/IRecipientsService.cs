using PackagesServer.Core.Dtos;

namespace PackagesServer.Core.ServiceContracts;
public interface IRecipientsService
{
    RecipientDto CreateRecipient(RecipientAddRequest recipient);
    List<RecipientDto> GetAllRecipients();
    RecipientDto GetRecipientById(int recipientId);
    RecipientDto UpdateRecipient(RecipientDto recipient);
    RecipientDto DeleteRecipientById(int recipientId);
}
