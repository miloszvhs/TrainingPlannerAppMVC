using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Domain.Exceptions
{
    public class EmailException : Exception
    {
        public EmailException(string email, Exception exception) : base($"Email \"{email}\" is invalid.", exception)
        {

        }
    }
}
