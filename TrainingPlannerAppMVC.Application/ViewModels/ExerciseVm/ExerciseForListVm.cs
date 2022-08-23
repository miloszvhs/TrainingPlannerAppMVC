using AutoMapper;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm;

public class ExerciseForListVm : IMapFrom<Exercise>
{
    public int Id { get; init; }
    public Guid UserId { get; init; }
    public string ExerciseName { get; set; }
    public string Category { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<Exercise, ExerciseForListVm>()
            .ForMember(x => x.Category, opt => opt.MapFrom(s => s.Category.CategoryName));
    }
}