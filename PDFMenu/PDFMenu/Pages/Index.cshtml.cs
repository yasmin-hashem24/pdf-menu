using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages;

public class IndexModel : PageModel
{

    private readonly EdgeDBClient _edgeDbClient;

    public List<RestaurantGot> TopRatedRestaurants { get; set; }
    public IndexModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }

    public async Task<IActionResult> OnGetAsync()
    {
        var query = "SELECT restaurant {email, restaurant, phone_number, rating,cover_photo} "+
                        "ORDER BY .rating DESC LIMIT 5";

        
            var result = await _edgeDbClient.QueryAsync<RestaurantGot>(query);
            TopRatedRestaurants = result.ToList();

        Console.WriteLine(TopRatedRestaurants[0].phone_number);
        return Page();
    }
    public IActionResult OnPostLogIn()
    {

        return RedirectToPage("Features/NormalUsers/Login");
    }

    public IActionResult OnPostSignUp()
    {
        return RedirectToPage("Features/NormalUsers/SignUp");
    }

}
public class RestaurantGot
{
    public string email { get; set; } = " ";
    public string phone_number { get; set; } = " ";
  
    public string restaurant { get; set; } = " ";

    public Int16 rating { get; set; } = 0;

    public string cover_photo { get; set; } = " ";

}