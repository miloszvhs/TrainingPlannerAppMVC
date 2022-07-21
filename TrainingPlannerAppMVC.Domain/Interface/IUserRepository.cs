using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Domain.Interface
{
    public interface IUserRepository
    {
        Guid AddUser(User user);
        Guid RemoveUserByUserId(Guid id);
        Guid UpdateUser(User user);
        User GetUserByUserId(Guid id);
        IQueryable<User> GetAllUsers();
    }
}
