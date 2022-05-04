using System.ComponentModel.DataAnnotations;

namespace ByteBank.Dominio.Entidades
{
    public class UsuarioApp
    {
        [Key]
        public int Id { get; set; }
        public string UserName { get; set; }

        [EmailAddress]
        public string Email { get; set; }

        public string Senha { get; set; }
    }
}
