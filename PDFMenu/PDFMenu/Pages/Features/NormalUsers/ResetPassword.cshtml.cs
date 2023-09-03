using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EdgeDB;
namespace PDFMenu.Pages.Features.NormalUsers;

public class ResetPasswordModel : PageModel
{
    public bool hide = false;

    public async Task<IActionResult> OnPostAsync()
    {
        hide = true;

        return Page();
    }

}
