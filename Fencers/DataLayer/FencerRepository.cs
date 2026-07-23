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
        var fencers = context.Fencers
            .AsNoTracking()
            .Include(u => u.FencerInformation)
            .AsQueryable();
        return await fencers.ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, string name, int UID)
    {
        var fencer = await context.Fencers.FirstOrDefaultAsync(u => u.Id == id);
        if (fencer is null)
            return false;

        fencer.Name = name;
        fencer.UID = UID;
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