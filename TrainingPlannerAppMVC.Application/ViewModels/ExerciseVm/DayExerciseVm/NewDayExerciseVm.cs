using AutoMapper;
using FluentValidation;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.ExerciseVm.DayExerciseVm;

public class NewDayExerciseVm : IMapFrom<DayExercise>
{
    public Guid DayId { get; init; }
    public int Id { get; init; }
    public DayExerciseDetailsVm ExerciseDetails { get; set; }
    public string ExerciseCategory { get; set; }

    public void Mapping(Profile profile)
    {
        profile.CreateMap<NewDayExerciseVm, DayExercise>()
            .ForPath(x => x.ExerciseCategory.Name, opt => opt.MapFrom(s => s.ExerciseCategory)).ReverseMap();
        profile.CreateMap<DayExerciseDetailsVm, DayExerciseDetails>().ReverseMap();
    }
}

public class NewDayExerciseValidation : AbstractValidator<NewDayExerciseVm>
{
    public NewDayExerciseValidation()
    {
        RuleFor(x => x.ExerciseCategory).NotEmpty();
        RuleFor(x => x.ExerciseDetails).SetValidator(new DayExerciseDetailsValidation());
    }
}