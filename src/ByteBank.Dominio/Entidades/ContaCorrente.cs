using System.ComponentModel.DataAnnotations;

namespace ByteBank.Dominio.Entidades
{
    public class ContaCorrente
    {
        [Key]
        public int Id { get; set; }

        public Guid Identificador { get; set; }
        public int Numero { get; set; }        
        
        private Cliente _cliente;

        public virtual Cliente Cliente
        {
            get => _cliente;
            set
            {
                if (value == null)
                    throw new FormatException("Cliente não pode ser nulo.");

                _cliente = value;
            }
        }

        private Agencia _agencia;
        public virtual Agencia Agencia
        {
            get { return _agencia; }
            set
            {
                if (value == null)
                    throw new FormatException("Agência não pode ser nulo.");

                _agencia = value;
            }
        }

        private double _saldo = 100;
        public double Saldo
        {
            get => _saldo;
            set
            {
                if (value <= 0)
                    throw new Exception("O valor para saldo não pode ser menor ou igual a zero.");
                _saldo += value;
            }
        }
        private Guid _pix;
        public Guid PixConta { get => _pix; set => _pix = value; }

        public ContaCorrente() { }
    }
}

