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
        var user = new User(request.email, Password.Create(request.password));
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
    public string Email2 { get; }
    public Password Password2 { get; }

    public User(string email2, Password password2)
    {
        Email2 = email2;
        Password2 = password2;
    }
}

public class Password
{
    public string Value { get; }

    private Password(string value)
    {
        Value = value;
    }

    public static Password Create(string value)
    {
        return new Password(value);
    }
}

public record UserRequest(string email, string password);