﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Models;

public class Estados
{
    [Key]
    public int EstadoId { get; set; }

    [Required(ErrorMessage = "El nombre del Estado es obligatorio")]
    public string? NombreEstado { get; set; }
}
