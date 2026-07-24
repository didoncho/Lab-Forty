using DatabaseLayer;
using BusinessLayer;

namespace ServiceLayer;

public class CompetitionService(CompetitionRepository repository)
{
    // CREATE
    public Task<Competition> CreateCompetitionAsync(Competition competition) => repository.CreateAsync(competition);
    
    // READ
    public Task<List<Competition>> GetAllCompetitionsAsync() => repository.GetAllAsync();
    
    // UPDATE
    public Task<bool> UpdateCompetitionAsync(int id, string name, DateOnly date) =>
        repository.UpdateAsync(id, name, date);
    
    // DELETE
    public Task<bool> DeleteCompetitionAsync(int id) => repository.DeleteAsync(id);
}