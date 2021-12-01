using Modul5HW1.Models.ResourceModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Services.Abstractions
{
    public interface IUnknownService
    {
        public Task<ResourceModel> GetResource(int id);
        public Task<ResourcesOnPageModel> GetResourceFromPage();
    }
}
