using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.NormalUsers;

public class LoginModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;
    public LoginModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnPostAsync()
    {

        return RedirectToPage("Features/Admins/AdminPage");
    }
}
