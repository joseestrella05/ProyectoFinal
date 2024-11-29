using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos;

public class OrdenesDto
{
    public int OrdenId { get; set; }
    public string? ClienteId { get; set; }
    public string? NombreCliente { get; set; }
    public string? ApellidoCliente { get; set; }
    public int EstadoId { get; set; }
    public string? Descripcion { get; set; }
    public string? Telefono { get; set; }
    public DateTime Fecha { get; set; }
    public ICollection<OrdenesDetalleDto> Detalle { get; set; } = new List<OrdenesDetalleDto>();
}
