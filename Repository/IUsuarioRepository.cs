using MagnaBackendNet.domain.models;

namespace MagnaBackendNet.Repository
{
    public interface IUsuarioRepository
    {
        ICollection<Usuario> GetUsers();
        Usuario GetById(int id);
        Usuario GetByUsername(string username);
        bool CreateUser(Usuario usuario);   
        bool Save();
    }
}
