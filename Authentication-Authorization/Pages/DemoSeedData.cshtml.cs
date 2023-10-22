using Authentication_Authorization.PageModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Runtime.CompilerServices;

namespace Authentication_Authorization.Pages
{
    //[Authorize(Policy ="AdminAccess")]
    public class DemoSeedDataModel : PageModel
    {
        private readonly IHttpClientFactory m_httpClientFactory;

        [BindProperty]
        public List<SeedData> LstSeedData { get; set; }

        public DemoSeedDataModel(IHttpClientFactory httpClientFactory)
        {
            m_httpClientFactory = httpClientFactory;
        }

        public async Task OnGetAsync()
        {
            var httpClient = m_httpClientFactory.CreateClient("WebAPIClient");

            try
            {
                LstSeedData = await httpClient.GetFromJsonAsync<List<SeedData>>("/api/SeedData");
            }
            catch (Exception ex)
            {

            }
        }
    }
}
