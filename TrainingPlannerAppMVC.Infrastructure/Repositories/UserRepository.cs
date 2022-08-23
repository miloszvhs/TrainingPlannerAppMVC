using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        
        public UserRepository(Context context)
        {
            _context = context;
        }

        public Guid AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
            return user.Id;
        }

        public IQueryable<User> GetAllUsers()
        {
            var users = _context.Users;
            return users;
        }

        public User GetUserByUserId(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);

            return user;
        }

        public Guid RemoveUser(Guid id)
        {
            var user = _context.Users.FirstOrDefault(x => x.Id == id);
            
            if (user != null)
            {
                _context.Users.Remove(user);
                _context.SaveChanges();
                return user.Id;
            }
            return Guid.Empty;
        }

        public Guid UpdateUser(User user)
        {
            var entity = _context.Users.FirstOrDefault(x => x.Id == user.Id);

            if (entity != null)
            {
                entity = user;
                _context.SaveChanges();
                return user.Id;
            }
            return Guid.Empty;
        }
    }
}
