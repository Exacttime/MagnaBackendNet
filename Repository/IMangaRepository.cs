using MagnaBackendNet.domain.models;
namespace MagnaBackendNet.Repository
{
    public interface IMangaRepository
    {
        ICollection<Manga> GetMangas();
    }
}
