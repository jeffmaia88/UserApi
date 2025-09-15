using System.ComponentModel.DataAnnotations;

namespace UserApi.Models
{
    public class UserRequest
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "O Nome é Obrigatório")]
        [MinLength(3, ErrorMessage = "O Nome precisa ter no mínimo 3 caracteres")]
        public string Nome { get; set; }
        [Required(ErrorMessage = "O Sobrenome é Obrigatório")]
        [MinLength(3, ErrorMessage = "O Sobrenome precisa ter no mínimo 3 caracteres")]
        public string Sobrenome { get; set; }
        [Required(ErrorMessage = "O CPF é Obrigatório")]
        [MinLength(11, ErrorMessage = "O CPF possui 11 caracteres")]
        public string Cpf { get; set; }
        [Required(ErrorMessage = "O Email é Obrigatório")]
        [MinLength(3, ErrorMessage = "O Email precisa ter no mínimo 3 caracteres")]
        public string Email { get; set; }
        [Required(ErrorMessage = "A Senha é Obrigatória")]
        public string Password { get; set; }
    }
}
