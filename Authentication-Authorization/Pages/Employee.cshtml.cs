using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace Authentication_Authorization.Pages
{
    //[Authorize(Policy="AdminAccess")]
    [Authorize(Policy = "MustBeAEmployee") ]
    public class EmployeeModel : PageModel
    {
        public void OnGet()
        {
        }
    }
}
