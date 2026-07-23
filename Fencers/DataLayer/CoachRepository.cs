using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CoachRepository(DataContext context)
{
    public async Task<Coach> CreateAsync(Coach coach)
    {
        await context.Coaches.AddAsync(coach);
        await context.SaveChangesAsync();
        return coach;
    }
    
    public async Task<bool> DeleteAsync(int id)
    {
        var coach = await context.Coaches.FirstOrDefaultAsync(u => u.Id == id);
        if (coach is null)
            return false;

        context.Coaches.Remove(coach);
        await context.SaveChangesAsync();
        return true;
    }
}