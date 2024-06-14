using MagnaBackendNet.domain.models;
namespace MagnaBackendNet.Repository
{
    public interface IMangaRepository
    {
        ICollection<Manga> GetMangas();
        Manga GetManga(string title);
        Manga GetMangaById(Guid id);

        ICollection<Manga> GetMangasByTitleContaning(string title);
        bool MangaExists(Guid mangaId);
        bool MangaExists(string title);
        bool CreateManga(Guid UsuarioId,Manga manga);
        bool Save();
    }
}
