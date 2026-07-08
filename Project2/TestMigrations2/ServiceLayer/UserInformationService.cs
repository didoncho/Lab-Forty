using Business;
using DatabaseLayer;

namespace ServiceLayer;

public class UserInformationService(UserInformationRepository userInformationRepository)
{
    public Task<List<UserInformation>> GetAllAsync() => userInformationRepository.GetAllAsync();

    public Task<UserInformation?> GetByIdAsync(int id) => userInformationRepository.GetAsync(id);

    public Task<bool> UpdateAsync(int id, string egn, string address) =>
        userInformationRepository.UpdateAsync(id, egn, address);

    public Task<bool> UpdateExecuteAsync(int id, string egn, string address) =>
        userInformationRepository.UpdateExecuteAsync(id, egn, address);

    public Task<bool> DeleteAsync(int id) => userInformationRepository.DeleteAsync(id);
}
