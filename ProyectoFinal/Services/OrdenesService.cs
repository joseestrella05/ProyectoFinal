using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class OrdenesService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<Ordenes>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<Ordenes>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
                .Include(m => m.MetodoPago)
            .ToListAsync();
    }

    public async Task<Ordenes> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
                .Include(m => m.MetodoPago)
            .FirstOrDefaultAsync(r => r.OrdenId == id);
    }

    public async Task<Ordenes> AddObject(Ordenes orden)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Ordenes.Add(orden);
        await context.SaveChangesAsync();
        return orden;
    }

    public async Task<bool> UpdateObject(Ordenes orden)
    {
        using var context = _contextFactory.CreateDbContext();

        var detalle = await context.OrdenesDetalle.Where(r => r.DetalleId == orden.OrdenId).ToListAsync();
        foreach (var item in detalle)
        {
            var producto = await context.Productos.FindAsync(item.ProductoId);
            if (producto != null)
            {
                producto.Cantidad += item.Cantidad;
                context.Entry(producto).State = EntityState.Modified;
                await context.SaveChangesAsync();
            }
        }

        if (orden.EstadoId != 4)
        {
            foreach (var item in orden.OrdenesDetalle)
            {
                var producto = await context.Productos.FindAsync(item.ProductoId);
                if (producto != null)
                {
                    producto.Cantidad -= item.Cantidad;
                    context.Entry(producto).State = EntityState.Modified;
                    await context.SaveChangesAsync();
                }
            }
        }

        context.Entry(orden).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var orden = await context.Ordenes.FindAsync(id);
        if (orden == null)
            return false;

        await context.OrdenesDetalle.Where(r => r.OrdenId == id).ExecuteDeleteAsync();
        context.Ordenes.Remove(orden);
        await context.SaveChangesAsync();
        return true;
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ordenes
            .AnyAsync(p => p.OrdenId != id && p.NombreCliente.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<Ordenes>> GetObjectByCondition(Expression<Func<Ordenes, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Ordenes
            .Include(d => d.OrdenesDetalle)
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
