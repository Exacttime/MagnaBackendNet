using MagnaBackendNet.domain.models;

namespace MagnaBackendNet.Repository.Impl
{
    public class MangaRepositoryImpl : IMangaRepository
    {
        private readonly DataContext _context;
        public MangaRepositoryImpl(DataContext context) { _context = context; }
        public ICollection<Manga> GetMangas()
        {
            return _context.Mangas.OrderBy(m => m.Id).ToList();
        }
        public Manga GetMangaById(Guid id)
        {
            Manga manga = _context.Mangas.First(m => m.Id == id);
            if(manga != null)
            {
                return manga;
            }
            else
            {
                throw new InvalidOperationException("Manga not found with the specified ID.");
            }
        }

    }
}
