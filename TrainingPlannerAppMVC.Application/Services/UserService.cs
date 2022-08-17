using AutoMapper;
using AutoMapper.QueryableExtensions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.Services
{
    public class UserService : IUserService
    {
        private IUserRepository _userRepository { get; set; }
        private IMapper _mapper { get; set; }

        public UserService(IMapper mapper, IUserRepository userRepository)
        {
            _userRepository = userRepository;
            _mapper = mapper;
        }

        public Guid AddUser(NewUserVm user)
        {
            var userModel = _mapper.Map<User>(user);
            var result = _userRepository.AddUser(userModel);
            return result;
        }

        public ListUserForListVm GetAllUsers()
        {
            var users = _userRepository.GetAllUsers()
                .ProjectTo<UserForListVm>(_mapper.ConfigurationProvider).ToList();

            var userList = new ListUserForListVm()
            {
                Users = users, 
                Count = users.Count,
            };

            return userList;
        }

        public UserDetailsVm GetUserById(Guid userId)
        {
            var user = _mapper.Map<UserDetailsVm>(_userRepository.GetUserByUserId(userId));
            return user;
        }

       /* public Guid UpdateUser(UserDetailsVm user)
        {
            var userModel = _mapper.Map<User>(user);
            _userRepository.UpdateUser(userModel);
            return user.Id;
        }*/
    }
}
