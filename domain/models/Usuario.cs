using System.ComponentModel.DataAnnotations;


namespace MagnaBackendNet.domain.models;

public class Usuario
{
    public Guid id { get; set; }
    public string username { get; set; }
    public string email { get; set; }
    public string password { get; set; }
    public ICollection<UsuarioManga> UsuarioManga { get; set; }
}

