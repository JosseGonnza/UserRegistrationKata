using Microsoft.AspNetCore.Mvc;

namespace UserRegistration.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly UserRepository userRepository;

    public UserController(UserRepository repository)
    {
        userRepository = repository;
    }
    
    [HttpPost]
    public IActionResult Post(UserRequest request)
    {
        var user = new User(request.email, request.password);
        userRepository.Save(user);
        return CreatedAtAction(nameof(Post), user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(userRepository.GetAllUsers());
    }
}

public class UserRepository
{
    private List<User> users = new List<User>();
    
    public void Save(User user)
    {
        user.Id = Guid.NewGuid();
        users.Add(user);
    }

    public List<User> GetAllUsers()
    {
        return users;
    }
}

public class User
{
    public Guid Id { get; set; }
    public string Email { get; }
    public string Password { get; }

    public User(string email, string password)
    {
        Email = email;
        Password = password;
    }
}

public record UserRequest(string email, string password);