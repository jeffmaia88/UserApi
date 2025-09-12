using UserApi.Entities;
using UserApi.Models;

namespace UserApi.Models.Converters
{
    public class UserConverter
    {


        public UserEntity RequestToEntity(UserRequest userRequest)
        {
            var userEntity = new UserEntity();

            userEntity.Id = userRequest.Id;
            userEntity.Nome = userRequest.Nome;
            userEntity.Sobrenome = userRequest.Sobrenome;
            userEntity.Cpf = userRequest.Cpf;
            userEntity.Password = userRequest.Password;
            userEntity.Email = userRequest.Email;

            return userEntity;
        }

        public UserRequest EntityToRequest(UserEntity userEntity)
        {
            var userRequest = new UserRequest();

            userRequest.Id = userEntity.Id;
            userRequest.Nome = userEntity.Nome;
            userRequest.Sobrenome= userEntity.Sobrenome;
            userRequest.Cpf = userEntity.Cpf;
            userRequest.Email = userEntity.Email;
            userRequest.Password = userEntity.Password;

            return userRequest;
        }

    }
}
