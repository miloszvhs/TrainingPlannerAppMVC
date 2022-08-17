using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TrainingPlannerAppMVC.Application.Mapping;
using TrainingPlannerAppMVC.Domain.Exceptions;
using TrainingPlannerAppMVC.Domain.ValueObjects;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm
{
    public class EmailVm : IMapFrom<Email>
    {
        public string UserName { get; set; }
        public string DomainName { get; set; }

        public static EmailVm For(string email)
        {
            var emailObj = new EmailVm();

            try
            {
                var index = email.IndexOf("@", StringComparison.Ordinal);
                emailObj.UserName = email.Substring(0, index);
                emailObj.DomainName = email.Substring(index + 1);
            }
            catch (Exception ex)
            {
                throw new EmailException(email, ex);
            }

            return emailObj;
        }

        public override string ToString()
        {
            return $"{UserName}@{DomainName}";
        }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Email, EmailVm>();
        }
    }
}
