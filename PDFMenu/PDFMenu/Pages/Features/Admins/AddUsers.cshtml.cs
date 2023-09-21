using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class AddUsersModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;

    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }

    [BindProperty]
    public user UserAdd { get; set; }
    public AddUsersModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync()
    {
        string emaile = HttpContext.Session.GetString("Email");
        var query = "SELECT restaurant {email} " +
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
        string emailna = HttpContext.Session.GetString("Email");


        var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$emailna
                    SET {
                         users += (INSERT user {
                            name := <str>$name,
                            email := <str>$email,
                            phone_number := <str>$phone_number
                        })
                    
                    }";
        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "name",UserAdd.name },
                        { "email", UserAdd.email},
                        { "emailna",emailna},
                        { "phone_number", UserAdd.phone_number }

        });
        return Page();
    }
}
