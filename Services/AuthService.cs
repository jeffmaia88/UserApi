using UserApi.Models;
using UserApi.Repositories;
using UserApi.Entities;
using UserApi.Models.Converters;


namespace UserApi.Services
{
    public class AuthService
    {
        private readonly AuthRepository _authRepository;

        public AuthService(AuthRepository repository)
        {
            _authRepository = repository;
        }

        public LoginResponse Authenticate( LoginRequest request)
        {
            var user = _authRepository.GetByEmail(request.Email);
            if (user == null)
                return null;

            var passwordValid = PasswordService.Verify(request.Password,user.Password );
            if (!passwordValid)
                return null;

            return LoginConverter.EntityToResponse(user, "Autenticado com Sucesso");
        }

    }
}
