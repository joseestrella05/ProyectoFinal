using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class EstadosService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<Estados>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<Estados>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Estados.ToListAsync();
    }

    public async Task<Estados> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Estados.FirstOrDefaultAsync(x => x.EstadoId == id);
    }

    public Task<bool> UpdateObject(Estados type)
    {
        throw new NotImplementedException();
    }

    public Task<Estados> AddObject(Estados type)
    {
        throw new NotImplementedException();
    }

    public Task<bool> DeleteObject(int id)
    {
        throw new NotImplementedException();
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Estados
            .AnyAsync(p => p.EstadoId != id && p.NombreEstado.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<Estados>> GetObjectByCondition(Expression<Func<Estados, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Estados
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}