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
                throw new InvalidOperationException("Manga com esse ID não encontrado.");
            }
        }
        public Manga GetManga(string title)
        {
            Manga manga = _context.Mangas.First(m => m.Title == title);
            if (manga != null)
            {
                return manga;
            }
            else
            {
                throw new InvalidOperationException("Manga com esse titulo não encontrado.");
            }
        }
        public ICollection<Manga> GetMangasByTitleContaning(string title)
        {
            return _context.Mangas.Where(m => m.Title.Contains(title)).ToList();
        }
        public bool MangaExists(Guid mangaId)
        {
            return _context.Mangas.Any(m => m.Id == mangaId);
        }
        public bool MangaExists(string mangaTitle)
        {
            return _context.Mangas.Any(m => m.Title == mangaTitle || m.Title.Contains(mangaTitle));
        }

        public bool CreateManga(Guid UsuarioId, Manga manga)
        {
            var usuarioAssociated = _context.Users.Where(u => u.Id == UsuarioId).FirstOrDefault();
            var usuarioManga = new UsuarioManga()
            {
                Usuario = usuarioAssociated,
                Manga = manga,
            };
            _context.Add(usuarioManga);
            _context.Add(manga);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0  ? true : false;
        }
    }
}
