using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;

namespace PDFMenu.Pages.Features.Admins;

public class PrivacyModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;
    public PrivacyModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public IActionResult OnPostUpdateEmail()
    {

        return RedirectToPage("UpdateEmail");
    }

    public IActionResult OnPostUpdatePassword()
    {
        return RedirectToPage("UpdatePassword");
    }


    public IActionResult OnPostAddUsers()
    {

        return RedirectToPage("AddUsers");
    }

    public IActionResult OnPostRemoveUsers()
    {
        return RedirectToPage("RemoveUsers");
    }
}
