using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authentication_Authorization.Pages
{
    [Authorize(Policy = "MustBelongToAdministration")]
    public class AdministrationModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
