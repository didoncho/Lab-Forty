using API.Contracts;
using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController(UserService userService) : ControllerBase
{
    [HttpGet]
    public async Task<IEnumerable<User>> GetAll([FromQuery] int? minOrdersCount, [FromQuery] string? region, [FromQuery] int page = 1, [FromQuery] int size = 10)
        => await userService.GetAllUsersAsync(minOrdersCount, region, page, size);

    [HttpGet("{id:int}")]
    public async Task<ActionResult<User>> GetById([FromRoute] int id)
        => await userService.GetUserByIdAsync(id) is { } user ? Ok(user) : NotFound();

    [HttpGet("by-email/{email}")]
    public async Task<ActionResult<User>> GetByEmail([FromRoute] string email)
        => await userService.GetUserByEmailAsync(email) is { } user ? Ok(user) : NotFound();

    // Creates the user and its UserInformation in one go.
    [HttpPost]
    public async Task<ActionResult<User>> Create([FromBody] CreateUserRequest request)
    {
        var user = await userService.CreateUserAsync(
            request.Email, request.Region, request.PhoneNumber, request.Egn, request.Address);

        return CreatedAtAction(nameof(GetById), new { id = user.Id }, user);
    }

    // Update variant #1: tracked entity + SaveChanges.
    [HttpPut("{id:int}")]
    public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateUserRequest request)
        => await userService.UpdateUserAsync(id, request.Email, request.Region, request.PhoneNumber)
            ? NoContent()
            : NotFound();

    // Update variant #2: ExecuteUpdate (no tracking). Requires a relational provider.
    [HttpPut("{id:int}/execute")]
    public async Task<IActionResult> UpdateExecute([FromRoute] int id, [FromBody] UpdateUserRequest request)
        => await userService.UpdateUserExecuteAsync(id, request.Email, request.Region, request.PhoneNumber)
            ? NoContent()
            : NotFound();

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> Delete([FromRoute] int id)
        => await userService.DeleteUserAsync(id) ? NoContent() : NotFound();
}
