using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class ProductosService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<Productos>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<Productos> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos.FindAsync(id);
    }

    public async Task<List<Productos>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .Include(c => c.Categoria)
            .ToListAsync();
    }

    public async Task<Productos> AddObject(Productos producto)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Productos.Add(producto);
        await context.SaveChangesAsync();
        return producto;
    }

    public async Task<bool> UpdateObject(Productos producto)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Productos.Update(producto);
        var modificado = await context.SaveChangesAsync() > 0;
        context.Entry(producto).State = EntityState.Modified;
        return modificado;
    }

    public async Task<Productos?> Search(int productoId)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos.AsNoTracking().FirstOrDefaultAsync(a => a.ProductoId == productoId);
    }

    public async Task<bool> DeleteObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var producto = await context.Productos.FindAsync(id);
        if (producto == null)
        {
            return false;
        }
        context.Productos.Remove(producto);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Exist(int id, string nombre)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .AnyAsync(p => p.ProductoId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<Productos>> GetObjectByCondition(Expression<Func<Productos, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.Productos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}
