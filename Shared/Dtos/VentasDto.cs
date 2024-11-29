using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos;

public class VentasDto
{
    public int VentaId { get; set; }
    public string? ClienteId { get; set; }
    public int OrdenId { get; set; }
    public int MetodoPagoId { get; set; }
    public DateTime Fecha { get; set; } = DateTime.Now;
    public double SubTotal { get; set; }
    public double Total { get; set; }
    public double ITBIS { get; set; }
    public double Devuelta { get; set; }
    public bool Eliminada { get; set; }
    public ICollection<VentasDetalleDto> VentasDetalle { get; set; } = new List<VentasDetalleDto>();
}
