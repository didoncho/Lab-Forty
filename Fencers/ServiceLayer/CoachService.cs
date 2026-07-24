using BusinessLayer;
using DatabaseLayer;
using DataLayer;

namespace ServiceLayer;

public class CoachService(CoachRepository repository)
{
    // CREATE
    public Task<Coach> CreateCoachAsync(Coach coach) => repository.CreateAsync(coach);
    
    // READ
    public Task<List<Coach>> GetAllCoachesAsync() => repository.GetAllAsync();
    
    // UPDATE
    public Task<bool> UpdateCoachAsync(int id, string name, DateOnly dateOfBirth,  string egn, string birthPlace, string address) =>
        repository.UpdateAsync(id, name, dateOfBirth, egn, birthPlace, address);
    
    // DELETE
    public Task<bool> DeleteCoachAsync(int id) => repository.DeleteAsync(id);
}