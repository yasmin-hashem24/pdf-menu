using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class LoginModel : PageModel
{

    public IActionResult OnPostReturn()
    {
        return RedirectToPage("/Index");
    }
}
