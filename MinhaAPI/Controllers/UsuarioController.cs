using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MinhaAPI.Models;
using MinhaAPI.Repositorio.Interfaces;

namespace MinhaAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public UsuarioController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpGet]
        public async Task<ActionResult<List<UsuarioModels>>> BuscarTodosUsuarios()
        {
            List<UsuarioModels> usuarios = await _usuarioRepositorio.BuscarTodosUsuarios();
            return Ok(usuarios);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UsuarioModels>> BuscarPorId(int id)
        {
            UsuarioModels usuario = await _usuarioRepositorio.BuscarPorId(id);
            return Ok(usuario);
        }

        [HttpPost("{id}")]
        public async Task<ActionResult<UsuarioModels>> CriarUsuario([FromBody] UsuarioModels usuarioModel)
        {
            UsuarioModels usuario = await _usuarioRepositorio.Adicionar(usuarioModel);
            return Ok(usuario);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UsuarioModels>> AlterarUsuario([FromBody] UsuarioModels usuarioModel , int id)
        {
            usuarioModel.Id = id;
            UsuarioModels usuario = await _usuarioRepositorio.Atualizar(usuarioModel, id);
            return Ok(usuario);
        }

        [HttpDelete("id")]
        public async Task<ActionResult<UsuarioModels>> DeletarUsuario(int id)
        {
            bool apagar = await _usuarioRepositorio.Apagar(id);
            return Ok(apagar);
        }
    }
}
