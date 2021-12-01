using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Models.ResourceModels
{
    public class ResourceModel
    {
        public int Id { get; set; }
        public int Name { get; set; }
        public string Year { get; set; }
        public string Color { get; set; }
        public string Pantone_value { get; set; }
        public SupportModel Support { get; set; }
    }
}
