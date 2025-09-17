using UserApi.Entities;
using UserApi.Repositories;
using UserApi.Models;
using UserApi.Models.Converters;
using Microsoft.AspNetCore.Http.HttpResults;

namespace UserApi.Services
{
    public class UserService
    {
        private readonly UserRepository _repository;

        public UserService(UserRepository repository)
        {
            _repository = repository;
        }

        public async Task<UserResult<UserResponse>> CreateUser(UserRequest request)
        {
           var user = UserConverter.RequestToEntity(request);

            await _repository.Create(user);


           var response = UserConverter.EntityToResponse(user); 
           return new UserResult<UserResponse>(response);

        }

        public async Task<List<UserResponse>> GetAllUsers()
        {
            var users = await _repository.GetUsers();
            
            return UserConverter.EntityToResponseList(users);
        }

        public async Task <UserResult<UserResponse>> GetById(int id)
        {
            var user = await _repository.ReadById(id);
            if (user == null)
            {
                return new UserResult<UserResponse>("05X01 - Usuário não encontrado");
            }

            var response = UserConverter.EntityToResponse(user);

            return new UserResult<UserResponse>(response);
        }

      
        public async Task <UserResult<UserResponse>> UpdateUser(int id, UserRequest request)
        {
            var user = await _repository.ReadById(id);
            if (user == null)
            {
                return new UserResult<UserResponse>("05X01 - Usuário não encontrado");
            }

            user.Nome = request.Nome;
            user.Sobrenome = request.Sobrenome;
            user.Cpf = request.Cpf;
            user.Email = request.Email;
            user.Password = request.Password;

            await _repository.Update(user);

           var response = UserConverter.EntityToResponse(user);
           return new UserResult<UserResponse>(response);

        }

        public async Task <UserResult<string>> DeleteUser(int id)
        {
            var user = await _repository.ReadById(id);
            if(user == null)
            {
                return new UserResult<string>("05X01 - Usuário não encontrado");
            }

            var nome = user.Nome;

            await _repository.Delete(user);
            var mensagem = $"Usuário {nome} excluído com sucesso";

            return new UserResult<string>(mensagem);
        }


    }
}
