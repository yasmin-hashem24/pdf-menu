using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class RemoveUsersModel : PageModel
{
    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    private readonly EdgeDBClient _edgeDbClient;

    [BindProperty]
    public List<user> Users { get; set; }
    public RemoveUsersModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }

    public async Task<IActionResult> OnGetAsync()
    {

        string emaile = HttpContext.Session.GetString("Email");
        var query = @"SELECT restaurant { users :{name, email,phone_number},} FILTER restaurant.email = <str>$email LIMIT 1;";

        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
                        {
                            { "email", emaile }
                        });

        if (returned != null)
        {
            RestaurantGot = returned;
            Users = returned.users;
            return Page();
        }
        else
        {

            return RedirectToPage("/Admins/AdminPage");
        }
    }

    public async Task<IActionResult> OnPostAsync()
    {

        var emailuser = Request.Form.FirstOrDefault(x => x.Key == "emailuser").Value.FirstOrDefault();
      
        var query = @"
            DELETE user
            FILTER user.email = <str>$emailuser;";

        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
        {
                { "emailuser", emailuser }
        });

        string emaile = HttpContext.Session.GetString("Email");
        var query1 = @"SELECT restaurant { users :{name, email,phone_number},} FILTER restaurant.email = <str>$email LIMIT 1;";
        
        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query1, new Dictionary<string, object>
                        {
                            { "email", emaile }
                        });

        if (returned != null)
        {
            RestaurantGot = returned;
            Users = returned.users;
            return Page();
        }
        else
        {

            return RedirectToPage("/Admins/AdminPage");
        }
    }
}
