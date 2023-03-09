using PackagesServer.Core.Dtos;
using PackagesServer.Core.RepositoryContracts;
using PackagesServer.Core.ServiceContracts;

namespace PackagesServer.Core.Services;
public class RecipientsService : IRecipientsService
{
    public readonly IRecipientsRepository _recipientRepository;
    public readonly MapperService _mapper;

    public RecipientsService(IRecipientsRepository recipientRepository, MapperService mapper)
    {
        _recipientRepository = recipientRepository;
        _mapper = mapper;
    }

    public RecipientDto CreateRecipient(RecipientAddRequest recipientAddRequest)
    {
        var recipientDto = new RecipientDto()
        {
            Name = recipientAddRequest.Name,
            Address = recipientAddRequest.Address,
        };
        var recipientEntity = _recipientRepository.Save(_mapper.ToEntity(recipientDto));
        
        return recipientEntity == null
            ? throw new ArgumentException("Creating recipient object was unsuccessful")
            : _mapper.ToDto(recipientEntity);
    }

    public RecipientDto DeleteRecipientById(int recipientId)
    {
        var recipient = _recipientRepository.FindById(recipientId) ?? throw new ArgumentException($"User was not found by id:{recipientId}");
        var isDeleted = _recipientRepository.DeleteById(recipientId);

        return isDeleted
            ? _mapper.ToDto(recipient)
            : throw new ArgumentException($"User deleting was unsuccessful by id:{recipient.Id}");
    }

    public List<RecipientDto> GetAllRecipients() =>
        _recipientRepository.FindAllRecipients()
        .Select(entity => _mapper.ToDto(entity))
        .ToList();

    public RecipientDto GetRecipientById(int recipientId)
    {
        var recipient = _recipientRepository.FindById(recipientId);
        return recipient == null 
            ? throw new ArgumentException($"User was not found by id:{recipientId}") 
            : _mapper.ToDto(recipient);
    }

    public RecipientDto UpdateRecipient(RecipientDto recipient)
    {
        var recipientEntity = _recipientRepository.Update(_mapper.ToEntity(recipient));

        return recipientEntity == null
           ? throw new ArgumentException($"User was not found by id:{recipient.Id}")
           : _mapper.ToDto(recipientEntity);
    }
}
