using SchoolApp.BLL.DTO;
using SchoolApp.BLL.Interfaces;
using SchoolApp.DAL.Interfaces;
using SchoolApp.DAL.Models;
using System.Linq;
using System;
using System.Collections.Generic;
using System.Text;

namespace SchoolApp.BLL.Services
{
    public class UserService:IUserService
    {
        IUnitOfWork Database { get; set; }
        public UserService(IUnitOfWork uow)
        {
            Database = uow;
        }

        public void CreateUser(UserDTO user)
        {
            Database.Users.Create(Map(user));
        }
        public void UpdateUser(UserDTO user)
        {
            Database.Users.Update(Map(user));
        }
        public UserDTO Login(UserDTO user)
        {
            User _user=Database.Users.Find(x => x.Name == user.Name && x.Password == user.Password).FirstOrDefault();
            UserDTO userDTO = _user != null ? new UserDTO { Id = _user.Id, Name = _user.Name, Password = _user.Password } : null;
            return userDTO; 
        }

        public void Dispose()
        {
            Database.Dispose();
        }
        internal User Map(UserDTO user)
        {
            return new User { Id = user.Id, Name = user.Name, Password=user.Password };
        }
        internal UserDTO Map(User user)
        {
            return new UserDTO { Id = user.Id, Name = user.Name, Password = user.Password };
        }
    }
}
