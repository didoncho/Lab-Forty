using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CompetitionFileRepository(DataContext context)
{
    // CREATE
    public async Task<Competition> CreateAsync(Competition competition)
    {
        await context.Competitions.AddAsync(competition);
        await context.SaveChangesAsync();
        return competition;
    }
    
    // READ
    public async Task<List<CompetitionFile>> GetAllAsync()
    {
        var competitionFile = context.CompetitionFiles
            .AsNoTracking()
            .AsQueryable();
        return await competitionFile.ToListAsync();
    }
}