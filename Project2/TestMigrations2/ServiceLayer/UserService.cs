using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class UserService(UserRepository userRepository)
{
    public List<User> GetAllUsers()
    {
        return userRepository.GetAll();
    }

    public void CreateUser(User user)
    {
        userRepository.Created(user);
    }

    public User? GetUserByEmail(string email)
    {
        return userRepository.GetByEmail(email);
    }

    public User? GetUserById(int id)
    {
        return userRepository.Get(id);
    }
}