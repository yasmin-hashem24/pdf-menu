using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class UpdatePasswordModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;


    public bool hide = false;
    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    [BindProperty]
    public string CurrentPassword { get; set; }


    [BindProperty]
    public string NewPassword { get; set; }
    public UpdatePasswordModel(EdgeDBClient edgeDbClient)
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
    public async Task<IActionResult> OnPostAsync()
    {
        hide = true;
        var email = HttpContext.Session.GetString("Email");
        string password = CurrentPassword;
        string newpassword = NewPassword;
        var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$email AND restaurant.password = <str>$password
                    SET {
                          
                        password := <str>$newpassword
                        
                        
                    
                    }";
        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                {
                    { "newpassword",newpassword },
                     { "password",password },
                     { "email",email }

                });


        return Page();
    }
}