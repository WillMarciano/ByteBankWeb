using ByteBank.Infraestrutura.Testes.DTO;
using System;

namespace ByteBank.Infraestrutura.Testes
{
    public interface IPixRepositorio
    {
       public PixDTO consultaPix(Guid pix);
    }
}
