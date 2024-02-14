﻿using Microsoft.AspNetCore.Components.Web;
using MinhaAPI.Models;

namespace MinhaAPI.Repositorio.Interfaces
{
    public interface IUsuarioRepositorio
    {
        Task<List<UsuarioModels>> BuscarTodosUsuarios();
        Task<UsuarioModels> BuscarPorId(int id);
        Task<UsuarioModels> Adicionar(UsuarioModels usuario);
        Task<UsuarioModels> Atualizar(UsuarioModels usuario, int id);
        Task<bool> Apagar (int id);
    }
}
