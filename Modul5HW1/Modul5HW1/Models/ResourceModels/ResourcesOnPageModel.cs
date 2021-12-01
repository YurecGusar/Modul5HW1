using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Models.ResourceModels
{
    public class ResourcesOnPageModel
    {
        public int Page { get; set; }
        public int Per_page { get; set; }
        public int Total { get; set; }
        public int Total_pages { get; set; }
        public List<ResourceModel> Data { get; set; }
        public SupportModel Support { get; set; }

    }
}
