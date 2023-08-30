using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages;

public class IndexModel : PageModel
{

    private readonly EdgeDBClient _edgeDbClient;
    public IndexModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public IActionResult OnPostLogIn()
    {

        return RedirectToPage("Features/Admins/Login");
    }

    public IActionResult OnPostSignUp()
    {
        return RedirectToPage("Features/Admins/SignUp");
    }
}