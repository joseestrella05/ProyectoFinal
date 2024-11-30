using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;

namespace ProyectoFinal.Services;

public class RolesService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServerAsp<IdentityRole>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<IdentityRole>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Roles.ToListAsync();
    }

    public async Task<IdentityRole> GetObject(string id)
    {
        using var context = _contextFactory.CreateDbContext();
        return (await context.Roles.FindAsync(id))!;
    }

    public async Task<IdentityRole> AddObject(IdentityRole type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Roles.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(IdentityRole type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(string id)
    {
        using var context = _contextFactory.CreateDbContext();
        var user = await context.Roles.FindAsync(id);
        if (user == null)
        {
            return false;
        }
        context.Roles.Remove(user);
        return await context.SaveChangesAsync() > 0;
    }
}
