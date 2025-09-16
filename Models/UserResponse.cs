using System.ComponentModel;
using System.Text.Json.Serialization;
using UserApi.Models.Converters;

namespace UserApi.Models
{
    public class UserResponse
    {
        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Cpf { get; set; }
        public string Email { get; set; }

           

    }
}
