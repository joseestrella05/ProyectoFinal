using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Tarjetas
{
    public int TarjetaId { get; set; }

    [StringLength(19, ErrorMessage = "El Número de Tarjeta debe tener 19 dígitos")]
    [RegularExpression(@"^\d{4}-\d{4}-\d{4}-\d{4}$", ErrorMessage = "El Número de Tarjeta debe tener el formato 0000-0000-0000-0000")]
    [Required(ErrorMessage = "Se requiere un Número de Tarjeta")]
    public string? NumeroTarjeta { get; set; }

    [RegularExpression(@"^[a-zA-Z\s]+$", ErrorMessage = "El Nombre debe contener solo letras.")]
    [Required(ErrorMessage = "Se requiere un Nombre")]
    public string? NombreTitular { get; set; }

    public DateTime FechaVencimiento { get; set; }

    [RegularExpression(@"^\d{3}$", ErrorMessage = "El Código de Seguridad debe tener 3 dígitos")]
    [Required(ErrorMessage = "Se requiere un Código de Seguridad")]
    public int CodigoSeguridad { get; set; }

    [Required(ErrorMessage = "Se requiere un Monto a Pagar")]
    public double MontoPagar { get; set; }
}
