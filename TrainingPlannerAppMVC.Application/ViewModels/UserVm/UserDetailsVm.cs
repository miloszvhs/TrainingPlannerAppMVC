using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.UserExerciseVm;
using TrainingPlannerAppMVC.Application.ViewModels.ProductVm.UserProductVm;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm;

public class UserDetailsVm : IMapFrom<User>
{
    public Guid Id { get; init; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public EmailVm UserEmail { get; set; }
    public ListProductForListVm Products { get; set; }
    public ListExerciseForListVm Exercises { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<User, UserDetailsVm>()
            .ForMember(x => x.UserEmail, opt => opt.MapFrom(s => s.UserEmail));
    }
}