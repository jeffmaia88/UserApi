using UserApi.Entities;

namespace UserApi.Models.Converters
{
    public static class LoginConverter
    {

        public static LoginResponse EntityToResponse(UserEntity userEntity, string message)
        {
            var response = new LoginResponse();

            response.Email = userEntity.Email;
            response.Nome = userEntity.Nome;
            response.Message = message;

            return response;

        }

    }
}
