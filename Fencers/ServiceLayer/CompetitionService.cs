using DatabaseLayer;
using BusinessLayer;
using ServiceLayer.Mappers;
using ServiceLayer.DTOs;

namespace ServiceLayer;

public class CompetitionService(CompetitionRepository repository)
{
    // CREATE
    public Task<Competition> CreateCompetitionAsync(Competition competition) => repository.CreateAsync(competition);
    
    // READ
    public async Task<List<CompetitionDTO>> GetAllCompetitionsAsync()
    {
        var results = await repository.GetAllAsync();
        return results.Select(CompetitionMapper.ToUI).ToList();
    }
        
    
    // UPDATE
    public Task<bool> UpdateCompetitionAsync(int id, string name, DateOnly date) =>
        repository.UpdateAsync(id, name, date);
    
    // DELETE
    public Task<bool> DeleteCompetitionAsync(int id) => repository.DeleteAsync(id);
}