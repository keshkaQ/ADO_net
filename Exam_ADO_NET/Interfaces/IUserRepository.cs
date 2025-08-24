using Exam_ADO_NET.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Exam_ADO_NET.Interfaces
{
    public interface IUserRepository
    {
        bool AddUser(UserModel userModel);
        bool DeleteUser(int userId);
        bool UpdateUser(UserModel userModel);
        List<UserModel> GetAllUsers();
        UserModel GetUserById(int userId);
    }
}
