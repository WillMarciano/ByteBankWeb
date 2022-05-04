﻿using ByteBank.Dominio.Entidades;

namespace ByteBank.Dominio.Interfaces.Repositorios
{
    public interface IUsuarioRepositorio : IDisposable
    {
        public List<UsuarioApp> ObterTodos();
        public UsuarioApp ObterPorId(int id);
        public bool Adicionar(UsuarioApp usuario);
        public bool Atualizar(int id, UsuarioApp usuario);
        public bool Excluir(int id);
    }
}
