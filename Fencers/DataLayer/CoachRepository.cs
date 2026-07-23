using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class CoachRepository(DataContext context)
{
    // CREATE
    public async Task<Coach> CreateAsync(Coach coach)
    {
        await context.Coaches.AddAsync(coach);
        await context.SaveChangesAsync();
        return coach;
    }
    
    // READ
    public async Task<List<Coach>> GetAllAsync()
    {
        var coach = context.Coaches
            .AsNoTracking()
            .AsQueryable();
        return await coach.ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, string name, DateOnly dateOfBirth,  string egn, string birthPlace, string address)
    {
        var coach = await context.Coaches.FirstOrDefaultAsync(u => u.Id == id);
        if (coach is null)
            return false;

        coach.Name = name;
        coach.DateOfBirth = dateOfBirth;
        coach.Egn = egn;
        coach.BirthPlace = birthPlace;
        coach.Address = address;
        await context.SaveChangesAsync();
        return true;
    }
    
    // DELETE
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