using DatabaseLayer;
using BusinessLayer;

namespace ServiceLayer;

public class CompetitionResultService(CompetitionResultRepository repository)
{
    // CREATE
    public Task<CompetitionResult> CreateCompetitionResultAsync(CompetitionResult competitionResult) => repository.CreateAsync(competitionResult);
    
    // READ
    public Task<List<CompetitionResult>> GetAllCompetitionResultsAsync() => repository.GetAllAsync();
    
    // UPDATE
    public Task<bool> UpdateCompetitionResultAsync(int id, int rank, int points) =>
        repository.UpdateAsync(id, rank, points);
    
    // DELETE
    public Task<bool> DeleteCompetitionResultAsync(int id) => repository.DeleteAsync(id);
}