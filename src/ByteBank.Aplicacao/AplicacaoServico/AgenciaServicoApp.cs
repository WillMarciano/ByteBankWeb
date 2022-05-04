using AutoMapper;
using ByteBank.Aplicacao.DTO;
using ByteBank.Aplicacao.Interfaces;
using ByteBank.Dominio.Entidades;
using ByteBank.Dominio.Interfaces.Servicos;

namespace ByteBank.Aplicacao.AplicacaoServico
{
    public class AgenciaServicoApp : IAgenciaServicoApp
    {
        private readonly IAgenciaServico _servico;
        private readonly Mapper _mapper;
        public AgenciaServicoApp(IAgenciaServico servico)
        {
            _servico = servico;
            var config = new MapperConfiguration(cfg =>
                   cfg.CreateMap<Agencia, AgenciaDTO>().ReverseMap());
            _mapper = new(config);
        }

        public void Dispose()
        {
            _servico.Dispose();
            GC.SuppressFinalize(this);
        }
        public bool Adicionar(AgenciaDTO agencia) => _servico.Adicionar(_mapper.Map<AgenciaDTO, Agencia>(agencia));

        public bool Atualizar(int id, AgenciaDTO agencia) => _servico.Atualizar(id, _mapper.Map<AgenciaDTO, Agencia>(agencia));

        public bool Excluir(int id) => _servico.Excluir(id);

        public AgenciaDTO ObterPorId(int id) => _mapper.Map<Agencia, AgenciaDTO>(_servico.ObterPorId(id));

        public AgenciaDTO ObterPorGuid(Guid guid) => _mapper.Map<Agencia, AgenciaDTO>(_servico.ObterPorGuid(guid));

        public List<AgenciaDTO> ObterTodos()
        {
            var agencias = _servico.ObterTodos();
            List<AgenciaDTO> agenciasDTO = _mapper.Map<List<Agencia>, List<AgenciaDTO>>(agencias);
            return agenciasDTO;
        }
    }
}
