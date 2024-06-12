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

    }
}
