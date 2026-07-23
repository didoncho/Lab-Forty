using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class FencerRepository(DataContext context)
{
    public async Task<Fencer> CreateAsync(Fencer fencer)
    {
        await context.Fencers.AddAsync(fencer);
        await context.SaveChangesAsync();
        return fencer;
    }
    
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