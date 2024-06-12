using MagnaBackendNet.domain.models;
using MagnaBackendNet.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MagnaBackendNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MangaController : ControllerBase
    {
        private readonly IMangaRepository _mangaRepository;
        public MangaController(IMangaRepository mangaRepository)
        {
            _mangaRepository = mangaRepository;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Manga>))]
        public IActionResult GetMangas()
        {
            var mangas = _mangaRepository.GetMangas();
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mangas);
        }
    }
}
