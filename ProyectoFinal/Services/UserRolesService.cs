using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;

namespace ProyectoFinal.Services;

public class UserRolesService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServerAsp<IdentityUserRole<string>>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<IdentityUserRole<string>>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.UserRoles.ToListAsync();
    }

    public async Task<IdentityUserRole<string>> GetObject(string id)
    {
        using var context = _contextFactory.CreateDbContext();
        return (await context.UserRoles.FirstOrDefaultAsync(r => r.RoleId == id))!;
    }

    public async Task<IdentityUserRole<string>> AddObject(IdentityUserRole<string> type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.UserRoles.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(IdentityUserRole<string> type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(string roleId)
    {
        using var context = _contextFactory.CreateDbContext();
        var userRole = await context.UserRoles.FindAsync(roleId);
        if (userRole == null)
        {
            return false;
        }
        context.UserRoles.Remove(userRole);
        return await context.SaveChangesAsync() > 0;
    }
}
