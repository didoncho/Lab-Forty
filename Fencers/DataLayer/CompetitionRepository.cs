using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CompetitionRepository(DataContext context)
{
    // CREATE
    public async Task<Competition> CreateAsync(Competition competition)
    {
        await context.Competitions.AddAsync(competition);
        await context.SaveChangesAsync();
        return competition;
    }
    
    // READ
    public async Task<List<Competition>> GetAllAsync()
    {
       return await context.Competitions
            .AsNoTracking()
            .Include(u => u.CompetitionResults)
            .ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, string name, DateOnly date)
    {
        var competiton = await context.Competitions.FirstOrDefaultAsync(u => u.Id == id);
        if (competiton is null)
            return false;
        
        competiton.Name = name;
        competiton.Date = date;
        await context.SaveChangesAsync();
        return true;
    }
    
    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var competition = await context.Competitions.FirstOrDefaultAsync(u => u.Id == id);
        if (competition is null)
            return false;

        context.Competitions.Remove(competition);
        await context.SaveChangesAsync();
        return true;
    }
}