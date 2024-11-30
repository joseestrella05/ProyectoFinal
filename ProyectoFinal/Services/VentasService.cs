using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class VentasService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<Ventas>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<Ventas>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ventas.Include(v => v.VentasDetalle).ToListAsync();
    }

    public async Task<Ventas> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return (await context.Ventas.Include(v => v.VentasDetalle).FirstOrDefaultAsync(v => v.VentaId == id))!;
    }

    public async Task<Ventas> AddObject(Ventas type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Ventas.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(Ventas type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var venta = await context.Ventas.FindAsync(id);
        if (venta == null)
            return false;

        await context.VentasDetalle.Where(v => v.VentaId == id).ExecuteDeleteAsync();
        context.Ventas.Remove(venta);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ventas
            .AnyAsync(p => p.OrdenId != id && p.NombreCliente.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<Ventas>> GetObjectByCondition(Expression<Func<Ventas, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ventas.Include(v => v.VentasDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}