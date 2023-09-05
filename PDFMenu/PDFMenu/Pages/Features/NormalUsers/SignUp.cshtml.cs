using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EdgeDB;

namespace PDFMenu.Pages.Features.NormalUsers;

public class SignUpModel : PageModel
{

    [BindProperty]
    public RestaurantInput restaurantIn { get; set; }

    [BindProperty]
    public string[] Countries { get; set; } = new string[] {
    "Algeria",
    "Angola",
    "Benin",
    "Botswana",
    "Burkina Faso",
    "Burundi",
    "Cameroon",
    "Cape Verde",
    "Central African Republic",
    "Chad",
    "Comoros",
    "Democratic Republic of the Congo",
    "Djibouti",
    "Egypt",
    "Equatorial Guinea",
    "Eritrea",
    "Eswatini (formerly Swaziland)",
    "Ethiopia",
    "Gabon",
    "Gambia"
};
    [BindProperty]
    public string[] Cities { get; set; }=
    new string[] {
        };

    [BindProperty]
    public string[] Districts { get; set; } =
    new string[] {
        };

    public bool hide = false;

    private readonly EdgeDBClient _edgeDbClient;
    public SignUpModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnPostAsync()
    {
       
        hide = true;
        var passwordHasher = new PasswordHasher<string>();
        string hashedPassword = passwordHasher.HashPassword(null, restaurantIn.Password);


            var result = await _edgeDbClient.QueryAsync<RestaurantInput>(
        "INSERT restaurant  { email := <str>$email, phone_number := <str>$phone_number, password := <str>$password, restaurant := <str>$restaurant, facebook := <str>$facebook, instagram := <str>$instagram, twitter := <str>$twitter, country := <str>$country, city := <str>$city, district := <str>$district, address := <str>$address }",
        new Dictionary<string, object>
        {
                { "email", restaurantIn.Email },
                { "phone_number", restaurantIn.PhoneNumber },
                { "restaurant", restaurantIn.Restaurant },
                { "facebook", restaurantIn.Facebook },
                { "instagram", restaurantIn.Instagram },
                { "twitter", restaurantIn.Twitter },
                { "country", restaurantIn.Country },
                { "city", restaurantIn.City },
                { "district", restaurantIn.District },
                { "address", restaurantIn.Address },
                { "password", hashedPassword}
        });

        return Page();
    }
  
}

