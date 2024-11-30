using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class MetodosPagosService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<MetodoPagos>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<MetodoPagos>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.MetodoPagos.ToListAsync();
    }

    public async Task<MetodoPagos> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.MetodoPagos.FirstOrDefaultAsync(x => x.MetodoPagoId == id);
    }

    public Task<bool> UpdateObject(MetodoPagos type)
    {
        throw new NotImplementedException();
    }

    public Task<MetodoPagos> AddObject(MetodoPagos type)
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
        return await context.MetodoPagos
            .AnyAsync(p => p.MetodoPagoId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<MetodoPagos>> GetObjectByCondition(Expression<Func<MetodoPagos, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.MetodoPagos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
