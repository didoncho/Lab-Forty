using BusinessLayer;
using DatabaseLayer;
using DataLayer;
using ServiceLayer.DTOs;
using ServiceLayer.Mappers;

namespace ServiceLayer;

public class CoachService(CoachRepository repository)
{
    // CREATE
    public async Task<CoachDTO> CreateCoachAsync(CoachDTO coach)
    {
        var toDB = CoachMapper.ToBusiness(coach);
        var toUI = await repository.CreateAsync(toDB);
        return CoachMapper.ToUI(toUI);
    }

    // READ
    public async Task<List<CoachDTO>> GetAllCoachesAsync()
    {
        var coaches = await repository.GetAllAsync();
        return coaches.Select(c => CoachMapper.ToUI(c)).ToList();
    }

    // UPDATE
    public Task<bool> UpdateCoachAsync(int id, string name, DateOnly dateOfBirth,  string egn, string birthPlace, string address) =>
        repository.UpdateAsync(id, name, dateOfBirth, egn, birthPlace, address);
    
    // DELETE
    public Task<bool> DeleteCoachAsync(int id) => repository.DeleteAsync(id);
}