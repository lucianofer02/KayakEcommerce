using Application.Models;
using Application.Models.Requests;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Interfaces
{
    public interface IUserService
    {
        User Create(UserCreateRequest userCreateRequest);
        void Delete(int  id);
        List<UserDto> GetAll();
        List<User> GetAllFullData();
        UserDto GetById(int id);
        void Update(int id, UserUpdateRequest userUpdateRequest);
    }
}
