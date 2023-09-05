using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class AdminPageModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;

   

    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    public AdminPageModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync(string emaile)
    {
        var query = "SELECT restaurant {email, password,restaurant,main_photo ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
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

}
