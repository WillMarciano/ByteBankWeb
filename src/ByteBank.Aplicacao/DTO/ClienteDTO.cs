namespace ByteBank.Aplicacao.DTO
{
    public class ClienteDTO
    {
        public int Id { get; set; }
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Profissao { get; set; }
        public Guid Identificador { get; set; }
        public ClienteDTO() => Identificador = Guid.NewGuid();
    }
}
