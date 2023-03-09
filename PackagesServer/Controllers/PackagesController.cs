using Microsoft.AspNetCore.Mvc;
using PackagesServer.Core.Dtos;
using PackagesServer.Core.ServiceContracts;
using Swashbuckle.AspNetCore.Annotations;

namespace PackagesServer.Controllers;

[ApiController]
[Route("[controller]")]
public class PackagesController : ControllerBase
{
    private readonly IPackagesService _packagesService;

    public PackagesController(IPackagesService packagesService)
    {
        _packagesService = packagesService;
    }

    [HttpGet]
    [SwaggerOperation("Returns all packages")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(List<PackageDto>))]
    public ActionResult<List<PackageDto>> GetAllPackages() =>
        _packagesService.GetAllPackages();

    [HttpGet("{id}")]
    [SwaggerOperation("Returns package by its ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(PackageDto))]
    public ActionResult<PackageDto> GetPackageById(int id) =>
        _packagesService.GetPackageById(id);

    [HttpPost]
    [SwaggerOperation("Creates new package object")]
    [SwaggerResponse(StatusCodes.Status201Created, "OK", typeof(PackageDto))]
    public ActionResult<PackageDto> CreatePackage(PackageAddRequest packageAddRequest) =>
        _packagesService.CreatePackage(packageAddRequest);

    [HttpPatch]
    [SwaggerOperation("Updates existed package")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(PackageDto))]
    public ActionResult<PackageDto> UpdatePackage(PackageDto packageDto) =>
        _packagesService.UpdatePackage(packageDto);

    [HttpDelete("{id}")]
    [SwaggerOperation("Deletes package by its ID")]
    [SwaggerResponse(StatusCodes.Status200OK, "OK", typeof(PackageDto))]
    public ActionResult<PackageDto> DeletePackage(int id) =>
        _packagesService.DeletePackage(id);
}
