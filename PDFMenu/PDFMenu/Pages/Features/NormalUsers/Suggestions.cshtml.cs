using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
using System.Text.Json;

using Microsoft.AspNetCore.Session;
namespace PDFMenu.Pages.Features.NormalUsers;

public class SuggestionsModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;
    public string City;
    public List<RestaurantGot> Restaurants { get; set; }
    public SuggestionsModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync(string name, string city)
    {
        string partialNameC = name.ToLower();
        string partialNameS = name.ToUpper();
        string partialNameT = char.ToUpper(name[0]) + name.Substring(1);
        Console.WriteLine(partialNameT);
        City = city;
        var query = "";
        if (city != "All Cities")
        {
            query = "SELECT restaurant { opening_hours, menu_upload_date, menu_pdf, email, tags, password, restaurant, main_photo, phone_number, cover_photo, facebook, instagram, twitter, country, address, city, district, rating } " +
                 "FILTER restaurant.city = <str>$city AND ( restaurant.restaurant LIKE '%' ++ <str>$partialNameT ++ '%' OR restaurant.restaurant LIKE '%' ++ <str>$partialNameC ++ '%' OR  restaurant.restaurant LIKE '%' ++ <str>$partialNameS ++ '%');";
        }
        else
        {
            query = "SELECT restaurant { opening_hours, menu_upload_date, menu_pdf, email, tags, password, restaurant, main_photo, phone_number, cover_photo, facebook, instagram, twitter, country, address, city, district, rating } " +
                 "FILTER restaurant.restaurant LIKE '%' ++ <str>$partialNameT ++ '%' OR restaurant.restaurant LIKE '%' ++ <str>$partialNameC ++ '%' OR  restaurant.restaurant LIKE '%' ++ <str>$partialNameS ++ '%';";

        }

        var result = await _edgeDbClient.QueryAsync<RestaurantGot>(query, new Dictionary<string, object>
        {
            { "city", city },
            { "partialNameC", partialNameC },
             { "partialNameS", partialNameS },
                 { "partialNameT", partialNameT }
        });
        Restaurants = result.ToList();
        return Page();
    }
}



