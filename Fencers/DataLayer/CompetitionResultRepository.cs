using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CompetitionResultRepository(DataContext context)
{
    // CREATE
    public async Task<CompetitionResult> CreateAsync(CompetitionResult competitionResult)
    {
        await context.CompetitionResults.AddAsync(competitionResult);
        await context.SaveChangesAsync();
        return competitionResult;
    }
    
    // READ
    public async Task<List<CompetitionResult>> GetAllAsync()
    {
        return await context.CompetitionResults
            .AsNoTracking()
            .Include(u => u.Competition)
            .Include(u => u.Fencer)
            .ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, int rank, int points)
    {
        var competitionResult = await context.CompetitionResults.FirstOrDefaultAsync(u => u.Id == id);
        if (competitionResult is null)
            return false;
        
        competitionResult.Rank = rank;
        competitionResult.Points = points;
        await context.SaveChangesAsync();
        return true;
    }
    
    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var competitionResult = await context.CompetitionResults.FirstOrDefaultAsync(u => u.Id == id);
        if (competitionResult is null)
            return false;

        context.CompetitionResults.Remove(competitionResult);
        await context.SaveChangesAsync();
        return true;
    }
}