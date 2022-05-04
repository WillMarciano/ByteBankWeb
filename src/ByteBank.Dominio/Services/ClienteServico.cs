using ByteBank.Dominio.Entidades;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;

namespace ByteBank.Dominio.Services
{
    public class ClienteServico : IClienteServico
    {
        private readonly IClienteRepositorio _repositorio;
        public ClienteServico(IClienteRepositorio repositorio) => _repositorio = repositorio;
        public bool Adicionar(Cliente cliente) => _repositorio.Adicionar(cliente);

        public bool Atualizar(int id, Cliente cliente) => _repositorio.Atualizar(id, cliente);

        public bool Excluir(int id) => _repositorio.Excluir(id);

        public Cliente ObterPorId(int id) => _repositorio.ObterPorId(id);

        public Cliente ObterPorGuid(Guid guid) => _repositorio.ObterPorGuid(guid);

        public List<Cliente> ObterTodos() => _repositorio.ObterTodos();

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
