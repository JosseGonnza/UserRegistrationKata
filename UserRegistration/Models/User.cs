using UserRegistration.ValueObjects;

namespace UserRegistration.Controllers;

public class User
{
    public Guid Id { get; set; }
    public string Email { get; }
    public Password Password { get; }

    public User(string email, Password password)
    {
        Email = email;
        Password = password;
    }
}