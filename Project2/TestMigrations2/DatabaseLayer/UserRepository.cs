using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class UserRepository(DataContext context)
{
    // Create: a User is inserted together with its UserInformation.
    // UserInformation is only ever created through the owning User (per requirement),
    // so the caller passes a User that already carries its UserInformation navigation.
    public async Task<User> CreateAsync(User user)
    {
        await context.Users.AddAsync(user);
        await context.SaveChangesAsync();
        return user;
    }

    public async Task<List<User>> GetAllAsync(int page = 1, int size = 10)
    {
        return await context.Users
            .AsNoTracking()
            .Include(u => u.UserInformation)
            .Skip((page - 1) * size)
            .Take(size)
            .ToListAsync();
    }

    public async Task<User?> GetAsync(int id)
    {
        return await context.Users
            .AsNoTracking()
            .Include(u => u.UserInformation)
            .FirstOrDefaultAsync(u => u.Id == id);
    }

    public async Task<User?> GetByEmailAsync(string email)
    {
        return await context.Users
            .AsNoTracking()
            .Include(u => u.UserInformation)
            .FirstOrDefaultAsync(u => u.Email == email);
    }

    // Update variant #1: load the tracked entity, mutate it, SaveChangesAsync.
    public async Task<bool> UpdateAsync(int id, string email, string region, string phoneNumber)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
            return false;

        user.Email = email;
        user.Region = region;
        user.PhoneNumber = phoneNumber;
        await context.SaveChangesAsync();
        return true;
    }

    // Update variant #2: set-based ExecuteUpdateAsync. Nothing is tracked and no
    // SaveChanges call is needed. (Not supported by the InMemory provider.)
    public async Task<bool> UpdateExecuteAsync(int id, string email, string region, string phoneNumber)
    {
        return await context.Users
            .Where(u => u.Id == id)
            .ExecuteUpdateAsync(setters => setters
                .SetProperty(u => u.Email, email)
                .SetProperty(u => u.Region, region)
                .SetProperty(u => u.PhoneNumber, phoneNumber)) > 0;
    }

    public async Task<bool> DeleteAsync(int id)
    {
        var user = await context.Users.FirstOrDefaultAsync(u => u.Id == id);
        if (user is null)
            return false;

        context.Users.Remove(user);
        await context.SaveChangesAsync();
        return true;
    }
}
