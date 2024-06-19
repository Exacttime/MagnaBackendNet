using MagnaBackendNet.domain.models;

namespace MagnaBackendNet.Repository.Impl
{
    public class UsuarioRepositoryImpl : IUsuarioRepository
    {
        private readonly DataContext _dataContext;
        public UsuarioRepositoryImpl(DataContext dataContext)
        {
            _dataContext = dataContext;
        }
        public bool CreateUser(Usuario usuario)
        {
            if (GetByUsername(usuario.Username) != null)
            {
                throw new InvalidOperationException("Usuario com esse username já existe.");
            }
            _dataContext.Add(usuario);
            return Save();
        }
        public Usuario GetById(Guid id)
        {
            return _dataContext.Users.Where(u => u.Id == id).First();
        }
        public Usuario GetByUsername(string username)
        {
            return _dataContext.Users.Where(u => u.Username.Equals(username)).FirstOrDefault();
        }
        public ICollection<Usuario> GetUsers()
        {
            return _dataContext.Users.OrderBy(u => u.Username).ToList();
        }
        public bool Save()
        {
            var saved = _dataContext.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}
