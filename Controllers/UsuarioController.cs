using AutoMapper;
using MagnaBackendNet.Domain.DTO;
using MagnaBackendNet.domain.models;
using MagnaBackendNet.Repository;
using Microsoft.AspNetCore.Mvc;

namespace MagnaBackendNet.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;
        public UsuarioController(IUsuarioRepository usuarioRepository, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _mapper = mapper;
        }
        [HttpGet]
        [ProducesResponseType(200, Type = typeof(IEnumerable<Usuario>))]
        public IActionResult GetUsuarios()
        {
            var users = _mapper.Map<List<UsuarioDTO>>(_usuarioRepository.GetUsers());
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return Ok(users);
        }
        [HttpPost]
        [ProducesResponseType(204)]
        [ProducesResponseType(400)]
        public IActionResult CreateUser([FromBody] UsuarioDTO createUser)
        {
            if (createUser == null)
                return BadRequest();

            if (!ModelState.IsValid)
                return BadRequest(ModelState);
            var userMap = _mapper.Map<Usuario>(createUser);
            if (!_usuarioRepository.CreateUser(userMap))
            {
                ModelState.AddModelError("", "Something went wrong while savin");
                return StatusCode(500, ModelState);
            }
            return Ok();
        }
    }
}
