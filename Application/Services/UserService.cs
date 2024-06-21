using Application.Interfaces;
using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using Domain.Exceptions;
using Domain.Interfaces;
using KayaksEcommerce.Application.Models.Requests;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class UserService : IUserService
    {
        private readonly IUserRepository _userRepository;
        public UserService(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public List<User> GetAllFullData()
        {
            return _userRepository.GetAll();
        }

        public UserDto GetById(int id)
        {
            var obj = _userRepository.GetById(id)
                ?? throw new NotFoundException(nameof(User), id);
            var dto = UserDto.Create(obj);
            return dto;
        }

        public List<UserDto> GetAll()
        {
            var list = _userRepository.GetAll();
            return UserDto.CreateList(list);
        }

        public User Create(UserCreateRequest userCreateRequest)
        {
            var obj = new User();
            obj.Name = userCreateRequest.Name;
            obj.Email = userCreateRequest.Email;
            obj.Password = userCreateRequest.Password;
            obj.Address = userCreateRequest.Address;
            return _userRepository.Add(obj);
        }

        public void Update(int id, UserUpdateRequest userUpdateRequest)
        {

            var obj = _userRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(User), id);

            if (userUpdateRequest.Name != string.Empty) obj.Name = userUpdateRequest.Name;

            if (userUpdateRequest.Email != string.Empty) obj.Email = userUpdateRequest.Email;

            if (userUpdateRequest.Password != string.Empty) obj.Password = userUpdateRequest.Password;

            if (userUpdateRequest.Address != string.Empty) obj.Address = userUpdateRequest.Address;

            _userRepository.Update(obj);

        }

        public void Delete(int id)
        {
            var obj = _userRepository.GetById(id);

            if (obj == null)
                throw new NotFoundException(nameof(User), id);

            _userRepository.Delete(obj);
        }
    }
}
