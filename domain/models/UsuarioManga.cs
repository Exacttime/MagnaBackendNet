using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MagnaBackendNet.domain.models
{
    public class UsuarioManga
    {
        public Guid UserId { get; set; }
        public Guid MangaId { get; set; }

        public Manga Manga { get; set; }
        public Usuario Usuario { get; set; }
    }
}
