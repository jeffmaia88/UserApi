using UserApi.Entities;
using UserApi.Models;

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
            userEntity.Password = userRequest.Password;
            userEntity.Email = userRequest.Email;

            return userEntity;
        }

        //public static UserRequest EntityToRequest(UserEntity userEntity)
        //{
        //    var userRequest = new UserRequest();

        //    userRequest.Id = userEntity.Id;
        //    userRequest.Nome = userEntity.Nome;
        //    userRequest.Sobrenome = userEntity.Sobrenome;
        //    userRequest.Cpf = userEntity.Cpf;
        //    userRequest.Email = userEntity.Email;
        //    userRequest.Password = userEntity.Password;

        //    return userRequest;
        //}

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
