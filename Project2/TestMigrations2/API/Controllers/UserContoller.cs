using Business;
using Microsoft.AspNetCore.Mvc;
using ServiceLayer;

namespace API.Controllers;

[ApiController]
[Route("[controller]")]

public class UserContoller(UserService userService) : ControllerBase
{
    [HttpGet("users/{email}")]
    public IEnumerable<User> GetUsers([FromRoute] string email, [FromQuery] string region,  [FromQuery] string phoneNumber)
    {
        return userService.GetAllUsers();
    }
    
    [HttpGet("users")]
    public IEnumerable<User> GetUsers([FromQuery] int page,  [FromQuery] int size)
    {
        return userService.GetAllUsers();
    }
    
    [HttpPost("AddUser/{email}")]
    public void AddOrder([FromRoute] string email, [FromQuery] string region,  [FromQuery] string phoneNumber)
    {
        userService.CreateUser(new User(){Email = email, Region = region, PhoneNumber = phoneNumber});
    }
}