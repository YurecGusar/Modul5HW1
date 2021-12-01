using Modul5HW1.Models.ResourceModels;
using Modul5HW1.Services.Abstractions;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Modul5HW1.Services
{
    public class UnknownService : IUnknownService
    {
        public async Task<ResourceModel> GetResource(int id)
        {
            var url = @$"https://reqres.in/api/unknown/{id}";
            var content = string.Empty;

            using (var httpClient = new HttpClient())
            {

                var result = await httpClient.GetAsync(url);

                if (result.StatusCode == HttpStatusCode.OK)
                {
                    content = await result.Content.ReadAsStringAsync();
                }
            }

            var obj = JsonConvert.DeserializeObject<ResourceModel>(content);

            return obj;
        }

        public Task<ResourcesOnPageModel> GetResourceFromPage()
        {
            throw new NotImplementedException();
        }
    }
}
