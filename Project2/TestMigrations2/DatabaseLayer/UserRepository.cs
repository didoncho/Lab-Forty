using System.Runtime.InteropServices;
using Business;
using Microsoft.EntityFrameworkCore;

namespace DatabaseLayer;

public class UserRepository(DataContext context)
{
    public List<User> GetAll(int page = 1, int size = 10)
    {
        Created();
        return context.Users.Skip((page - 1) * size).Take(size).ToList();
    }

    public void Created()
    {
        context.Users.Add(new User()
        {
            Email = "Email",
            Region =  "Region",
            PhoneNumber = "PhoneNumber",
            Orders = []
        });
        context.SaveChanges();
    }
    
    public void Created(User user)
    {
        context.Users.Add(user);
        context.SaveChanges();
    }

    public User? GetByEmail(string email)
    {
        Created();
        return context.Users.FirstOrDefault(p => p.Email == email);
    }

    public User? Get(int id)
    {
        Created();
        return context.Users.AsNoTracking().FirstOrDefault(p => p.Id == id);
    }

    public void Update(int id, string newEmail)
    {
        Created();
        var user = Get(id);
        if (user == null)
            return;
        
        user.Email = newEmail;
        context.SaveChanges();
    }
}