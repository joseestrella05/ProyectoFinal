using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Dtos;

public class ProductosDto
{
    public int ProductoId { get; set; }
    public int CategoriaId { get; set; }
    public double Precio { get; set; }
    public int Cantidad { get; set; }
    public int ITBIS { get; set; }
    public bool Disponible { get; set; }
}
