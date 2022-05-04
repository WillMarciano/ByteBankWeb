using ByteBank.Dominio.Entidades;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;

namespace ByteBank.Dominio.Services
{
    public class AgenciaServico : IAgenciaServico
    {
        private readonly IAgenciaRepositorio _repositorio;
        public AgenciaServico(IAgenciaRepositorio repositorio)
        {
            _repositorio = repositorio;
        }
        public bool Adicionar(Agencia agencia) => _repositorio.Adicionar(agencia);

        public bool Atualizar(int id, Agencia agencia) => _repositorio.Atualizar(id, agencia);

        public bool Excluir(int id) => _repositorio.Excluir(id);

        public Agencia ObterPorId(int id) => _repositorio.ObterPorId(id);

        public Agencia ObterPorGuid(Guid guid) => _repositorio.ObterPorGuid(guid);

        public List<Agencia> ObterTodos() => _repositorio.ObterTodos();

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
