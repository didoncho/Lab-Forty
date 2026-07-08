using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class UserService(UserRepository userRepository)
{
    public Task<List<User>> GetAllUsersAsync(int page = 1, int size = 10) => userRepository.GetAllAsync(page, size);

    public Task<User?> GetUserByIdAsync(int id) => userRepository.GetAsync(id);

    public Task<User?> GetUserByEmailAsync(string email) => userRepository.GetByEmailAsync(email);

    // Creates the User together with its UserInformation.
    public Task<User> CreateUserAsync(string email, string region, string phoneNumber, string egn, string address)
    {
        var user = new User
        {
            Email = email,
            Region = region,
            PhoneNumber = phoneNumber,
            UserInformation = new UserInformation
            {
                Egn = egn,
                Address = address
            }
        };

        return userRepository.CreateAsync(user);
    }

    public Task<bool> UpdateUserAsync(int id, string email, string region, string phoneNumber) =>
        userRepository.UpdateAsync(id, email, region, phoneNumber);

    public Task<bool> UpdateUserExecuteAsync(int id, string email, string region, string phoneNumber) =>
        userRepository.UpdateExecuteAsync(id, email, region, phoneNumber);

    public Task<bool> DeleteUserAsync(int id) => userRepository.DeleteAsync(id);
}
