using Microsoft.AspNetCore.Identity;

namespace Shared.Dtos;

public class AplicationUserDto : IdentityUser
{
    public string? Nombre { get; set; }
    public string? Apellido { get; set; }
    public int Cedula { get; set; }
}
