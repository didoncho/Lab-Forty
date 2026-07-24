using BusinessLayer;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class FencerInformationRepository(DataContext context)
{
    // CREATE
    public async Task<FencerInformation> CreateAsync(FencerInformation fencerInformation)
    {
        await context.FencerInformations.AddAsync(fencerInformation);
        await context.SaveChangesAsync();
        return fencerInformation;
    }
    
    // READ
    public async Task<List<FencerInformation>> GetAllAsync()
    {
        return await context.FencerInformations
            .AsNoTracking()
            .Include(u => u.Fencer)
            .ToListAsync();
    }
    
    // UPDATE
    public async Task<bool> UpdateAsync(int id, DateOnly dateOfBirth,  string egn, string birthPlace, string address)
    {
        var fencerInformation = await context.FencerInformations.FirstOrDefaultAsync(u => u.Id == id);
        if (fencerInformation is null)
            return false;
        
        fencerInformation.DateOfBirth = dateOfBirth;
        fencerInformation.Egn = egn;
        fencerInformation.BirthPlace = birthPlace;
        fencerInformation.Address = address;
        await context.SaveChangesAsync();
        return true;
    }
    
    // DELETE
    public async Task<bool> DeleteAsync(int id)
    {
        var fencerInformation = await context.FencerInformations.FirstOrDefaultAsync(u => u.Id == id);
        if (fencerInformation is null)
            return false;

        context.FencerInformations.Remove(fencerInformation);
        await context.SaveChangesAsync();
        return true;
    }
}