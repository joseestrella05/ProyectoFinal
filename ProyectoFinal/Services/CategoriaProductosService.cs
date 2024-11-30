using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class CategoriaProductosService(IDbContextFactory<ApplicationDbContext> contextFactory) : IServer<CategoriaProductos>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory = contextFactory;

    public async Task<List<CategoriaProductos>> GetAllObject()
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.CategoriaProductos.ToListAsync();
    }

    public async Task<CategoriaProductos> GetObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        return (await context.CategoriaProductos.FindAsync(id))!;
    }

    public async Task<CategoriaProductos> AddObject(CategoriaProductos type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.CategoriaProductos.Add(type);
        await context.SaveChangesAsync();
        return type;
    }

    public async Task<bool> UpdateObject(CategoriaProductos type)
    {
        using var context = _contextFactory.CreateDbContext();
        context.Entry(type).State = EntityState.Modified;
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> DeleteObject(int id)
    {
        using var context = _contextFactory.CreateDbContext();
        var categoria = await context.CategoriaProductos.FindAsync(id);
        if (categoria == null)
            return false;
        context.CategoriaProductos.Remove(categoria);
        return await context.SaveChangesAsync() > 0;
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.CategoriaProductos
            .AnyAsync(p => p.CategoriaId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
    }

    public async Task<List<CategoriaProductos>> GetObjectByCondition(Expression<Func<CategoriaProductos, bool>> expression)
    {
        using var context = _contextFactory.CreateDbContext();
        return await context.CategoriaProductos
            .AsNoTracking()
            .Where(expression)
            .ToListAsync();
    }
}