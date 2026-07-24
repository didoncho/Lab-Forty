using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CompetitionFileRepository(DataContext context)
{
    // CREATE
    public async Task<CompetitionFile> CreateAsync(CompetitionFile competitionFile)
    {
        await context.CompetitionFiles.AddAsync(competitionFile);
        await context.SaveChangesAsync();
        return competitionFile;
    }
    
    // READ
    public async Task<List<CompetitionFile>> GetAllAsync()
    {
        return await context.CompetitionFiles.ToListAsync();
    }
}