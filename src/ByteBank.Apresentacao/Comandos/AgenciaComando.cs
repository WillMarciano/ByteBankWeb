using ByteBank.Aplicacao.AplicacaoServico;
using ByteBank.Aplicacao.DTO;
using ByteBank.Dados.Repositorio;
using ByteBank.Dominio.Interfaces.Repositorios;
using ByteBank.Dominio.Interfaces.Servicos;
using ByteBank.Dominio.Services;

namespace ByteBank.Apresentacao.Comandos
{
    internal class AgenciaComando
    {
        readonly IAgenciaRepositorio _repositorio;
        readonly IAgenciaServico _servico;
        readonly AgenciaServicoApp agenciaServicoApp;
        public AgenciaComando()
        {
            _repositorio = new AgenciaRepositorio();
            _servico = new AgenciaServico(_repositorio);
            agenciaServicoApp = new AgenciaServicoApp(_servico);
        }

        public bool Adicionar(AgenciaDTO agencia) => agenciaServicoApp.Adicionar(agencia);
        public bool Atualizar(int id, AgenciaDTO agencia) => agenciaServicoApp.Atualizar(id, agencia);
        public bool Excluir(int id) => agenciaServicoApp.Excluir(id);
        public AgenciaDTO ObterPorId(int id) => agenciaServicoApp.ObterPorId(id);
        public List<AgenciaDTO> ObterTodos() => agenciaServicoApp.ObterTodos();
    }
}
