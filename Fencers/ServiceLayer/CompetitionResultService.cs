using DatabaseLayer;
using BusinessLayer;
using ServiceLayer.DTOs;
using ServiceLayer.Mappers;

namespace ServiceLayer;

public class CompetitionResultService(CompetitionResultRepository repository)
{
    // CREATE
    public Task<CompetitionResult> CreateCompetitionResultAsync(CompetitionResult competitionResult) => repository.CreateAsync(competitionResult);
    
    // READ
    public Task<List<CompetitionResult>> GetAllCompetitionResultsAsync() => repository.GetAllAsync();

    public async Task<List<CompetitionResultDTO>> GetResultsByCompetitionIdAsync(int userId)
    { 
        var domainResults = await repository.GetResultsByCompetitionIdAsync(userId);
        return domainResults.Select(CompetitionResultMapper.ToUI).ToList();
    }
    
    // UPDATE
    public Task<bool> UpdateCompetitionResultAsync(int id, int rank, int points) =>
        repository.UpdateAsync(id, rank, points);
    
    // DELETE
    public Task<bool> DeleteCompetitionResultAsync(int id) => repository.DeleteAsync(id);
}