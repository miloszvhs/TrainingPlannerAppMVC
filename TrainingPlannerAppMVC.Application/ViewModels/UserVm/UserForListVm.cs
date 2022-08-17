using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Model;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm
{
    public class UserForListVm : IMapFrom<User>
    {
        public Guid Id { get; init; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public EmailVm UserEmail { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserForListVm>()
                .ForMember(x => x.UserEmail, opt => opt.MapFrom(s => s.UserEmail));
        }
    }
}
