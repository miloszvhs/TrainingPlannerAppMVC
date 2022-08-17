using AutoMapper;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm
{
    public class NewUserVm : IMapFrom<User>
    {
        public Guid Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserEmail { get; set; }
    
        public void Mapping(Profile profile)
        {
            profile.CreateMap<NewUserVm, User>()
                .ForMember(x => x.UserEmail, opt => opt.MapFrom(s => Email.For(s.UserEmail)));
        }
    }

    public class NewUserValidation : AbstractValidator<NewUserVm>
    {
        public NewUserValidation()
        {
            RuleFor(x => x.UserEmail).EmailAddress();
            RuleFor(x => x.FirstName).MaximumLength(40);
            RuleFor(x => x.LastName).MaximumLength(40);
        }
    }
}
