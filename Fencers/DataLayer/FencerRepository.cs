using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class FencerRepository(DataContext context)
{
    // CREATE
    public async Task<Fencer> CreateAsync(Fencer fencer)
    {
        await context.Fencers.AddAsync(fencer);
        await context.SaveChangesAsync();
        return fencer;
    }
    
    // READ
    public async Task<List<Fencer>> GetAllAsync()
    {
        return await context.Fencers
            .AsNoTracking()
            .Include(u => u.FencerInformation)
            .ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, string name, int uid, DateOnly dateOfBirth, string egn, string birthPlace, string address)
    {
        var fencer = await context.Fencers.Include(u => u.FencerInformation).FirstOrDefaultAsync(u => u.Id == id);
        if (fencer is null)
            return false;

        fencer.Name = name;
        fencer.UID = uid;
        fencer.FencerInformation.DateOfBirth = dateOfBirth;
        fencer.FencerInformation.Egn = egn;
        fencer.FencerInformation.BirthPlace = birthPlace;
        fencer.FencerInformation.Address = address;
        await context.SaveChangesAsync();
        return true;
    }
    
    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var fencer = await context.Fencers.FirstOrDefaultAsync(u => u.Id == id);
        if (fencer is null)
            return false;

        context.Fencers.Remove(fencer);
        await context.SaveChangesAsync();
        return true;
    }
}