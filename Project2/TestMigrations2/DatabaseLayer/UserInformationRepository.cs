using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

// UserInformation is created only through the User entity, so this repository
// intentionally exposes no Create method - just Read / Update / Delete.
public class UserInformationRepository(DataContext context)
{
    public async Task<List<UserInformation>> GetAllAsync()
    {
        return await context.UserInformations
            .AsNoTracking()
            .Include(i => i.User)
            .ToListAsync();
    }

    public async Task<UserInformation?> GetAsync(int id)
    {
        return await context.UserInformations
            .AsNoTracking()
            .Include(i => i.User)
            .FirstOrDefaultAsync(i => i.Id == id);
    }

    // Update variant #1: tracked entity + SaveChangesAsync.
    public async Task<bool> UpdateAsync(int id, string egn, string address)
    {
        var info = await context.UserInformations.FirstOrDefaultAsync(i => i.Id == id);
        if (info is null)
            return false;

        info.Egn = egn;
        info.Address = address;
        await context.SaveChangesAsync();
        return true;
    }

    // Update variant #2: ExecuteUpdateAsync, no tracking. (Not supported by InMemory.)
    public async Task<bool> UpdateExecuteAsync(int id, string egn, string address)
    {
        return await context.UserInformations
            .Where(i => i.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(i => i.Egn, egn)
                .SetProperty(i => i.Address, address)) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var info = await context.UserInformations.FirstOrDefaultAsync(i => i.Id == id);
        if (info is null)
            return false;

        context.UserInformations.Remove(info);
        await context.SaveChangesAsync();
        return true;
    }
}
