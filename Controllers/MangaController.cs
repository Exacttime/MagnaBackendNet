using AutoMapper;
using MagnaBackendNet.domain.models;
using MagnaBackendNet.Domain.DTO;
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
        private readonly IMapper _mapper;
        public MangaController(IMangaRepository mangaRepository, IMapper mapper)
        {
            _mangaRepository = mangaRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200,Type = typeof(IEnumerable<Manga>))]
        public IActionResult GetMangas()
        {
            var mangas = _mapper.Map<List<MangaDTO>>(_mangaRepository.GetMangas());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(mangas);
        }
        [HttpGet("{id}")]
        [ProducesResponseType(200, Type = typeof(Manga))]
        [ProducesResponseType(400)]
        public ActionResult<Manga> GetMangaById(Guid id)
        {
            if (!_mangaRepository.MangaExists(id))
                return NotFound();

            var manga = _mapper.Map<MangaDTO>(_mangaRepository.GetMangaById(id));
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(manga);
        }
        [HttpGet("{title}")]
        [ProducesResponseType(200, Type = typeof(Manga))]
        [ProducesResponseType(400)]
        public ActionResult<Manga> GetManga(string title)
        {
            if (!_mangaRepository.MangaExists(title))
                return NotFound();

            var manga = _mapper.Map<MangaDTO>(_mangaRepository.GetManga(title));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(manga);
        }
        [HttpGet("titles")]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Manga>))]
        [ProducesResponseType(400)]
        public ActionResult<Manga> GetMangaByTitleContaning([FromQuery]string title)
        {
            if (!_mangaRepository.MangaExists(title))
                return NotFound();

            var mangas = _mapper.Map<List<MangaDTO>>(_mangaRepository.GetMangasByTitleContaning(title));

            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            return Ok(mangas);
        }
    }
}
