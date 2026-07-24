using BusinessLayer;
using DatabaseLayer;

namespace ServiceLayer;

public class CompetitionFileService(CompetitionFileRepository repository)
{
    // CREATE
    public Task<CompetitionFile> CreateCompetitionFileAsync(CompetitionFile competitionFile) => repository.CreateAsync(competitionFile);
    
    // READ
    public Task<List<CompetitionFile>> GetAllCompetitionFilesAsync() => repository.GetAllAsync();
}