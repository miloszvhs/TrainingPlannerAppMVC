using AutoMapper;
using AutoMapper.QueryableExtensions;
using TrainingPlannerAppMVC.Application.Interfaces;
using TrainingPlannerAppMVC.Application.ViewModels.UserVm;
using TrainingPlannerAppMVC.Domain.Interface;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.Services;

public class UserService : IUserService
{
    public UserService(IMapper mapper, IUserRepository userRepository)
    {
        _userRepository = userRepository;
        _mapper = mapper;
    }

    private IUserRepository _userRepository { get; }
    private IMapper _mapper { get; }

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

        var userList = new ListUserForListVm
        {
            Users = users,
            Count = users.Count
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