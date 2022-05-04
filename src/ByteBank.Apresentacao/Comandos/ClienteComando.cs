using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Aplicacao.DTO;
using ByteBank.Dados.Repositorio;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Dominio.Services;

namespace ByteBank.Apresentacao.Comandos
{
    internal class ClienteComando
    {
        readonly IClienteRepositorio _repositorio;
        readonly IClienteServico _servico;
        readonly ClienteServicoApp clienteServicoApp;
        public ClienteComando()
        {
            _repositorio = new ClienteRepositorio();
            _servico = new ClienteServico(_repositorio);
            clienteServicoApp = new ClienteServicoApp(_servico);
        }

        public bool Adicionar(ClienteDTO cliente) => clienteServicoApp.Adicionar(cliente);
        public bool Atualizar(int id, ClienteDTO cliente) => clienteServicoApp.Atualizar(id, cliente);
        public bool Excluir(int id) => clienteServicoApp.Excluir(id);
        public ClienteDTO ObterPorId(int id) => clienteServicoApp.ObterPorId(id);
        public ClienteDTO ObterPorGuid(Guid guid) => clienteServicoApp.ObterPorGuid(guid);
        public List<ClienteDTO> ObterTodos() => clienteServicoApp.ObterTodos();

    }
}
