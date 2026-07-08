using API.Contracts;
using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

// No POST here on purpose: UserInformation is created only through the User entity.
[ApiController]
[Route("[controller]")]
public class UserInformationController(UserInformationService userInformationService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<UserInformation>> GetAll() => await userInformationService.GetAllAsync();

    [HttpGet("{id:int}")]
    public async Task<ActionResult<UserInformation>> GetById([FromRoute] int id)
        => await userInformationService.GetByIdAsync(id) is { } info ? Ok(info) : NotFound();

    // Update variant #1: tracked entity + SaveChanges.
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserInformationRequest request)
        => await userInformationService.UpdateAsync(id, request.Egn, request.Address)
            ? NoContent()
            : NotFound();

    // Update variant #2: ExecuteUpdate (no tracking). Requires a relational provider.
    [HttpPut("{id:int}/execute")]
    public async Task<IActionResult> UpdateExecute([FromRoute] int id, [FromBody] UpdateUserInformationRequest request)
        => await userInformationService.UpdateExecuteAsync(id, request.Egn, request.Address)
            ? NoContent()
            : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => await userInformationService.DeleteAsync(id) ? NoContent() : NotFound();
}
