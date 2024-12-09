using Microsoft.EntityFrameworkCore;
using ProyectoFinal.Data;
using Shared.Interfaces;
using Shared.Models;
using System.Linq.Expressions;

namespace ProyectoFinal.Services;

public class MetodosPagosService : IServer<MetodoPagos>
{
    private readonly IDbContextFactory<ApplicationDbContext> _contextFactory;

    public MetodosPagosService(IDbContextFactory<ApplicationDbContext> contextFactory)
    {
        _contextFactory = contextFactory;
    }

    public async Task<List<MetodoPagos>> GetAllObject()
    {
        try
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.MetodoPagos.ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener los métodos de pago: {ex.Message}");
            return new List<MetodoPagos>();
        }
    }

    public async Task<MetodoPagos> GetObject(int id)
    {
        try
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.MetodoPagos.FirstOrDefaultAsync(x => x.MetodoPagoId == id)
                ?? throw new KeyNotFoundException($"No se encontró el método de pago con ID {id}.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al obtener el método de pago con ID {id}: {ex.Message}");
            throw;
        }
    }

    public Task<bool> UpdateObject(MetodoPagos type)
    {
        throw new NotImplementedException("Actualizar métodos de pago no está implementado.");
    }

    public Task<MetodoPagos> AddObject(MetodoPagos type)
    {
        throw new NotImplementedException("Agregar nuevos métodos de pago no está implementado.");
    }

    public Task<bool> DeleteObject(int id)
    {
        throw new NotImplementedException("Eliminar métodos de pago no está implementado.");
    }

    public async Task<bool> Exist(int id, string? nombre)
    {
        try
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.MetodoPagos
                .AnyAsync(p => p.MetodoPagoId != id && p.Nombre.ToLower().Equals(nombre.ToLower()));
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al verificar existencia: {ex.Message}");
            return false;
        }
    }

    public async Task<List<MetodoPagos>> GetObjectByCondition(Expression<Func<MetodoPagos, bool>> expression)
    {
        try
        {
            using var context = _contextFactory.CreateDbContext();
            return await context.MetodoPagos
                .AsNoTracking()
                .Where(expression)
                .ToListAsync();
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error al filtrar métodos de pago: {ex.Message}");
            return new List<MetodoPagos>();
        }
    }
}
