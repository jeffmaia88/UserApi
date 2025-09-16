using UserApi.Entities;
using UserApi.Models;
using UserApi.Services;

namespace UserApi.Models.Converters
{
    public static class UserConverter
    {


        public static UserEntity RequestToEntity(UserRequest userRequest)
        {
            var userEntity = new UserEntity();

            userEntity.Id = userRequest.Id;
            userEntity.Nome = userRequest.Nome;
            userEntity.Sobrenome = userRequest.Sobrenome;
            userEntity.Cpf = userRequest.Cpf;
            userEntity.Password = PasswordService.Hash(userRequest.Password);
            userEntity.Email = userRequest.Email.Trim().ToLower();

            return userEntity;
        }

  
        public static UserResponse EntityToResponse(UserEntity userEntity)
        {
            var userResponse = new UserResponse();

            userResponse.Nome = userEntity.Nome;
            userResponse.Sobrenome = userEntity.Sobrenome;
            userResponse.Cpf = userEntity.Cpf;
            userResponse.Email = userEntity.Email;
            userResponse.Data = DateTime.Now;

            return userResponse;

        }

        public static List<UserResponse> EntityToResponseList(List<UserEntity> userEntities)
        {
            return userEntities.Select(EntityToResponse).ToList();
        }

    }
}
