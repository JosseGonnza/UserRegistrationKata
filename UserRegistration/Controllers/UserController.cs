using Microsoft.AspNetCore.Mvc;
using UserRegistration.Repositories;
using UserRegistration.ValueObjects;

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
        var user = new User(request.Email, Password.Create(request.Password));
        var existingUser = userRepository.GetAllUsers().FirstOrDefault(u => u.Email == request.Email);
        if (existingUser != null)
        {
            return BadRequest("Email already exist");
        }
        userRepository.Save(user);
        return CreatedAtAction(nameof(Post), user);
    }

    [HttpGet]
    public IActionResult GetAll()
    {
        return Ok(userRepository.GetAllUsers());
    }
}