using Microsoft.AspNetCore.Mvc;
using PackagesServer.Core.Dtos;
using PackagesServer.Core.ServiceContracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PackagesServer.Controllers;

[ApiController]
[Route("[controller]")]
public class RecipientController : ControllerBase
{
    private readonly IRecipientsService _recipientsService;

    public RecipientController(IRecipientsService recipientsService)
    {
        _recipientsService = recipientsService;
    }

    [HttpGet]
    [SwaggerOperation(Summary = "Returns all recipients")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(RecipientDto))]
    public ActionResult<List<RecipientDto>> GetAllRecipients() =>
         _recipientsService.GetAllRecipients();


    [HttpGet("{id}")]
    [SwaggerOperation(Summary = "Returns recipient by its ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(RecipientDto))]
    public ActionResult<RecipientDto> GetRecipientById(int id) =>
        _recipientsService.GetRecipientById(id);

    [HttpPost]
    [SwaggerOperation("Creates new recipient object")]
    [SwaggerResponse(StatusCodes.Status201Created, "OK", typeof(RecipientDto))]
    public ActionResult<RecipientDto> CreateRecipient(RecipientAddRequest recipientAddRequest) =>
        _recipientsService.CreateRecipient(recipientAddRequest);

    [HttpPatch]
    [SwaggerOperation("Updates recipient object")]
    [SwaggerResponse(StatusCodes.Status201Created, "OK", typeof(RecipientDto))]
    public ActionResult<RecipientDto> UpdateRecipient(RecipientDto recipientDto) =>
        _recipientsService.UpdateRecipient(recipientDto);

    [HttpDelete("{id}")]
    [SwaggerOperation("Deletes recipient object by its id")]
    [SwaggerResponse(StatusCodes.Status201Created, "OK", typeof(RecipientDto))]
    public ActionResult<RecipientDto> DeleteRecipient(int id) =>
        _recipientsService.DeleteRecipientById(id);
}
