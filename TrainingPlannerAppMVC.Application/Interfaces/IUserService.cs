using TrainingPlannerAppMVC.Application.ViewModels.UserVm;

namespace TrainingPlannerAppMVC.Application.Interfaces;

public interface IUserService
{
    Guid AddUser(NewUserVm user);
    ListUserForListVm GetAllUsers();

    UserDetailsVm GetUserById(Guid userId);
    //Guid UpdateUser(UserDetailsVm user);
}