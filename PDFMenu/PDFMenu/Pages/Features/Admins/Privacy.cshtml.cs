using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;

namespace PDFMenu.Pages.Features.Admins;

public class PrivacyModel : PageModel
{

    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    private readonly EdgeDBClient _edgeDbClient;
    public PrivacyModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        string emaile = HttpContext.Session.GetString("Email");
        var query = "SELECT restaurant { email,tags, password} " +
                      "FILTER restaurant.email = <str>$email LIMIT 1;";


        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
    {
        { "email", emaile }
    });

        if (returned != null)
        {

            RestaurantGot = returned;

            return Page();
        }
        else
        {

            return RedirectToPage("/Admins/Login");
        }
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
