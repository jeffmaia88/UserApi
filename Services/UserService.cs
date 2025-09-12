using UserApi.Entities;
using UserApi.Repositories;
using UserApi.Models;
using UserApi.Models.Converters;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public UserResponse CreateUser(UserRequest request)
        {
           var user = UserConverter.RequestToEntity(request);

            _repository.Create(user);

           return UserConverter.EntityToResponse(user); 

        }

        public List<UserResponse> GetAllUsers()
        {
            var users = _repository.GetUsers();
            
            return UserConverter.EntityToResponseList(users);
        }

        public UserResponse GetById(int id)
        {
            var user = _repository.ReadById(id);
            if (user == null)
            {
                throw new Exception("Usuário não Encontrado");
            }

            return UserConverter.EntityToResponse(user);
        }

        public UserResponse UpdateUser(int id, UserRequest request)
        {
            var user = _repository.ReadById(id);
            if (user == null)
            {
                throw new Exception("Usuário não encontrado");
            }

            user.Nome = request.Nome;
            user.Sobrenome = request.Sobrenome;
            user.Cpf = request.Cpf;
            user.Email = request.Email;
            user.Password = request.Password;

            _repository.Update(user);

            return UserConverter.EntityToResponse(user);

        }

        public void DeleteUser(int id)
        {
            var user = _repository.ReadById(id);
            if(user == null)
            {
                throw new Exception("Usuario Nao Encontrado");
            }

            _repository.Delete(user);
        }


    }
}
