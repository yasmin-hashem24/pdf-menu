using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
using System.Net;
namespace PDFMenu.Pages;

public class IndexModel : PageModel
{

    private readonly EdgeDBClient _edgeDbClient;
    public List<RestaurantGot> TopRatedRestaurants { get; set; }
    public List<RestaurantGot> RestaurantsForSearch { get; set; }

    public string[] CitiesOfSearch { get; set; } = new string[] {
    "Alexandria",
    "Aswan",
    "Cairo",
    "El Minya",
    "Giza",
    "Hurghada",
    "Ismailia",
    "Luxor",
    "Marsa Alam",
    "Port Said",
    "Sharm El Sheikh",
    "Saqqara",
    "Tanta"
};

    public IndexModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync()
    {
        var query = "SELECT restaurant {email, restaurant, phone_number, rating,cover_photo,main_photo} "+
                        "ORDER BY .rating DESC LIMIT 5";

        
        var result = await _edgeDbClient.QueryAsync<RestaurantGot>(query);
        TopRatedRestaurants = result.ToList();
        var query1 = "SELECT restaurant {email, restaurant, phone_number, rating,cover_photo,main_photo} ";
        var result1 = await _edgeDbClient.QueryAsync<RestaurantGot>(query);
        RestaurantsForSearch = result1.ToList();
        return Page();
    }
    [HttpPost]
    public async Task<IActionResult> OnPostAsync()
    {
        
        string selectedRestaurant = Request.Form["autocomplete_input"];
        string selectedCity = Request.Form["city_filter"];
        Console.WriteLine(selectedRestaurant);
        var query = "SELECT restaurant {email, password,restaurant ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
                      "FILTER restaurant.restaurant = <str>$selectedRestaurant AND restaurant.city = <str>$selectedCity LIMIT 1;";

        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
        {
            { "selectedRestaurant", selectedRestaurant },
            { "selectedCity", selectedCity }
        });

        if (returned != null)
        { 
            return RedirectToPage("/Features/NormalUsers/RestaurantPage", new { restaurant = selectedRestaurant });
        }
        else
        {
            return RedirectToPage("/Features/NormalUsers/Suggestions", new { name = selectedRestaurant, city = selectedCity });

        }
    }
}

