using ByteBank.Dominio.Entidades;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;

namespace ByteBank.Dominio.Services
{
    public class ContaCorrenteServico : IContaCorrenteServico
    {
        private readonly IContaCorrenteRepositorio _repositorio;
        public ContaCorrenteServico(IContaCorrenteRepositorio repositorio) => _repositorio = repositorio;
        public bool Adicionar(ContaCorrente conta) => _repositorio.Adicionar(conta);

        public bool Atualizar(int id, ContaCorrente conta) => _repositorio.Atualizar(id, conta);

        public bool Excluir(int id) => _repositorio.Excluir(id);

        public ContaCorrente ObterPorId(int id) => _repositorio.ObterPorId(id);

        public ContaCorrente ObterPorGuid(Guid guid) => _repositorio.ObterPorGuid(guid);

        public List<ContaCorrente> ObterTodos() => _repositorio.ObterTodos();

        public void Dispose()
        {
            _repositorio.Dispose();
            GC.SuppressFinalize(this);
        }
    }
}
