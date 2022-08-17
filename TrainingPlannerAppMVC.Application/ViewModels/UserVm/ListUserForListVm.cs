using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.ViewModels.UserVm
{
    public class ListUserForListVm
    {
        public List<UserForListVm> Users { get; set; }
        public int Count { get; set; }
    }
}
