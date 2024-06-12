namespace MagnaBackendNet.domain.models;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

public class Manga
{
    public Guid Id { get; set; }
    public string Title { get; set; }
    public string Description { get; set; }
    public int Chapter { get; set; }
    public string ImageUrl { get; set; }
    public ICollection<UsuarioManga> UsuarioManga { get; set; }

}
