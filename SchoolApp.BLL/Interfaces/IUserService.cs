using SchoolApp.BLL.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Interfaces
{
    public interface IUserService
    {
        UserDTO Login(UserDTO user);
        void CreateUser(UserDTO user);
        void UpdateUser(UserDTO user);
        void Dispose();
    }
}
