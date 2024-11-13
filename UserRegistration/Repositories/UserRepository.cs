using UserRegistration.Controllers;

namespace UserRegistration.Repositories;

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