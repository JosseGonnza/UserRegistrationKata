using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    [HttpPost]
    public IActionResult Post(UserRequest request)
    {
        var user = new User(request.email, request.password);
        return CreatedAtAction(nameof(Post), user);
    }
}

public class User
{
    public Guid Id { get; }
    public string Email { get; }
    public string Password { get; }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }
}

public record UserRequest(string email, string password);