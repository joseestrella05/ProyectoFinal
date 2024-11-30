using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;

namespace ProyectoFinal.Services;

public class UsersService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServerAsp<ApplicationUser>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<ApplicationUser> GetObject(string id)
    {
        using var context = _contextFactory.CreateDbContext();
        return (await context.Users.FindAsync(id))!;
    }

    public async Task<List<ApplicationUser>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Users.ToListAsync();
    }

    public async Task<ApplicationUser> AddObject(ApplicationUser type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Users.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(ApplicationUser type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(string id)
    {
        using var context = _contextFactory.CreateDbContext();
        var user = await context.Users.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        context.Users.Remove(user);
        return await context.SaveChangesAsync() > 0;
    }
}