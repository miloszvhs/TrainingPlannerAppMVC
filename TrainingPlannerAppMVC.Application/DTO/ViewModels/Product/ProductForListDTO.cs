using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TrainingPlannerAppMVC.Application.DTO.ViewModels.Product
{
    public class ProductForListDTO
    {
        public ICollection<ProductDetailsDTO> Products { get; set; }
    }
}
