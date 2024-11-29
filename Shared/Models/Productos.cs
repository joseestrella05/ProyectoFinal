using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Productos
{
    [Key]
    public int ProductoId { get; set; }

    [ForeignKey("Categorias")]
    public int CategoriaId { get; set; }

    // [Required(ErrorMessage = "Se Requiere una Categoria")]
    public CategoriaProductos? Categoria { get; set; }

    [Required(ErrorMessage = "Se Requiere un Nombre")]
    [RegularExpression("^[a-zA-Z0-9 ]+$", ErrorMessage = "El Nombre debe Contener Solo Letras y Números.")]
    public string? Nombre { get; set; } = string.Empty;

    [Required(ErrorMessage = "Se Requiere de una Descripción")]
    [RegularExpression("^[a-zA-Z0-9 ,]+$", ErrorMessage = "La Descripción debe contener solo Letras y Números")]
    public string? Descripcion { get; set; } = string.Empty;

    [Range(0, 1000, ErrorMessage = "La Cantidad debe estar entre 0 y 1000")]
    [Required(ErrorMessage = "Indique la Cantidad")]
    public int Cantidad { get; set; }

    [Required(ErrorMessage = "Indique el Precio")]
    [Range(0.01, 1000000000, ErrorMessage = "El Precio debe estar 0.01 y 1000000000")]
    public float Precio { get; set; }
    public float ITBIS { get; set; }
    public bool Disponible { get; set; }
    public string? ImagenUrl { get; set; }
}
