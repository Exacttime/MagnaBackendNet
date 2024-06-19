using System.ComponentModel.DataAnnotations;


namespace MagnaBackendNet.domain.models;

public class Usuario
{
    public Guid Id { get; set; }
    public string Username { get; set; }
    public string Email { get; set; }
    public string Password { get; set; }
    public ICollection<UsuarioManga>? UsuarioManga { get; set; }
}

