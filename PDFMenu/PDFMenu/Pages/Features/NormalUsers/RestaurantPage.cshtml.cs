using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.NormalUsers;

public class RestaurantPageModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;

    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    public RestaurantPageModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync(string restaurant)
    {
        var query = "SELECT restaurant { opening_hours, menu_upload_date,menu_pdf,email,tags, password,restaurant,main_photo ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
                      "FILTER restaurant.restaurant = <str>$restaurant LIMIT 1;";

        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
        {
            { "restaurant", restaurant }
        });

        if (returned != null)
        {

            RestaurantGot = returned;

            return Page();
        }
        else
        {

            return RedirectToPage("/Index");
        }
    }
}
