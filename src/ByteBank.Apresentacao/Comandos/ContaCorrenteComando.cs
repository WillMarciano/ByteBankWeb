using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Aplicacao.DTO;
using ByteBank.Dados.Repositorio;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Dominio.Services;

namespace ByteBank.Apresentacao.Comandos
{
    internal class ContaCorrenteComando
    {
        readonly IContaCorrenteRepositorio _repositorio;
        readonly IContaCorrenteServico _servico;
        readonly IClienteServico _cliente;
        IAgenciaServico _agencia;
        readonly ContaCorrenteServicoApp contaCorrenteServicoApp;
        public ContaCorrenteComando()
        {
            _repositorio = new ContaCorrenteRepositorio();
            _servico = new ContaCorrenteServico(_repositorio);
            contaCorrenteServicoApp = new ContaCorrenteServicoApp(_servico, _agencia, _cliente);
        }

        public bool Adicionar(ContaCorrenteDTO conta) => contaCorrenteServicoApp.Adicionar(conta);
        public bool Atualizar(int id, ContaCorrenteDTO conta) => contaCorrenteServicoApp.Atualizar(id, conta);

        public bool Excluir(int id) => contaCorrenteServicoApp.Excluir(id);
        public ContaCorrenteDTO ObterPorId(int id) => contaCorrenteServicoApp.ObterPorId(id);
        public List<ContaCorrenteDTO> ObterTodos() => contaCorrenteServicoApp.ObterTodos();
    }
}
