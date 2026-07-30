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
        var coachEntity = CoachMapper.ToBusiness(coach);
        var createdCoach = await repository.CreateAsync(coachEntity);
        return CoachMapper.ToUI(createdCoach);
    }

    // READ
    public async Task<List<CoachDTO>> GetAllCoachesAsync()
    {
        var coaches = await repository.GetAllAsync();
        return coaches.Select(c => CoachMapper.ToUI(c)).ToList();
    }

    public async Task<List<AttachCoachDTO>> GetAllAttachCoachesAsync()
    {
        var allCoaches = await repository.GetAllAsync();
        return allCoaches.Select(c => CoachMapper.ToAttachDTO(c)).ToList();
    }

    // UPDATE
    public Task<bool> UpdateCoachAsync(int id, string name, DateOnly dateOfBirth,  string egn, string birthPlace, string address) =>
        repository.UpdateAsync(id, name, dateOfBirth, egn, birthPlace, address);
    
    // DELETE
    public Task<bool> DeleteCoachAsync(int id) => repository.DeleteAsync(id);
}