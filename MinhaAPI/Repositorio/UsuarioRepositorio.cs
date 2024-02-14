using Microsoft.EntityFrameworkCore;
using MinhaAPI.Data;
using MinhaAPI.Models;
using MinhaAPI.Repositorio.Interfaces;

namespace MinhaAPI.Repositorio
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly SistemaDeTarefasDbContext _dbContext;
        public UsuarioRepositorio(SistemaDeTarefasDbContext sistemaDeTarefasDbContext)
        {
            _dbContext = sistemaDeTarefasDbContext;
        }

        public async Task<UsuarioModels> BuscarPorId(int id)
        {
            return await _dbContext.Usuarios.FirstOrDefaultAsync(x => x.Id == id);
        }

        public async Task<List<UsuarioModels>> BuscarTodosUsuarios()
        {
            return await _dbContext.Usuarios.ToListAsync();
        }
        public async Task<UsuarioModels> Adicionar(UsuarioModels usuario)
        {
            await _dbContext.Usuarios.AddAsync(usuario);
            await _dbContext.SaveChangesAsync();

            return usuario;
        }

        public async Task<UsuarioModels> Atualizar(UsuarioModels usuario, int id)
        {
            UsuarioModels usuarioPorId = await BuscarPorId(id);

            if (usuarioPorId == null)
            {
                throw new Exception($"Usuario para o ID: '{id}' não foi encontrado.");
            }

            usuarioPorId.Nome = usuario.Nome;
            usuarioPorId.Email = usuario.Email;

            _dbContext.Update(usuarioPorId);
            await _dbContext.SaveChangesAsync();

            return usuarioPorId;
        }

        public async Task<bool> Apagar(int id)
        {
            {
                UsuarioModels usuarioPorId = await BuscarPorId(id);

                if (usuarioPorId == null)
                {
                    throw new Exception($"Usuario para o ID: '{id}' não foi encontrado.");
                }

                _dbContext.Usuarios.Remove(usuarioPorId);
                await _dbContext.SaveChangesAsync();

                return true;
            }

        }
    }
}
