using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins;

public class SettingsModel : PageModel
{
    [BindProperty]
    public string Restaurant { get; set; }

    [BindProperty]
    public string OpeningHours { get; set; }
    [BindProperty]
    public string PhoneNumber { get; set; }

    [BindProperty]
    public string Instagram { get; set; }
    [BindProperty]
    public string Facebook { get; set; }

    [BindProperty]
    public string Twitter { get; set; }
    [BindProperty]
    public string Tags { get; set; }

    [BindProperty]
    public string Country { get; set; }

    [BindProperty]
    public string Address { get; set; }

    [BindProperty]
    public string City { get; set; }
    [BindProperty]
    public string District { get; set; }

    [BindProperty]
    public IFormFile File { get; set; }



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
    public string[] Cities { get; set; } =
    new string[] {
        };

    [BindProperty]
    public string[] Districts { get; set; } =
    new string[] {
        };

    public bool hide = false;

    private readonly EdgeDBClient _edgeDbClient;
  
    public SettingsModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
        
    }

    public async Task<IActionResult> OnGetAsync()
    {

        string email = HttpContext.Session.GetString("Email");
        var query = "SELECT restaurant {facebook,restaurant,phone_number,instagram,twitter,country,city,district,address,opening_hours} " +
                       "FILTER restaurant.email = <str>$email LIMIT 1;";

        var parameters = new Dictionary<string, object>
            {
                { "email", email }
            };

        var restaurant = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, parameters);


        Facebook = restaurant.facebook;
        Restaurant = restaurant.restaurant;
        Instagram = restaurant.instagram;
        Address = restaurant.address;
        PhoneNumber = restaurant.phone_number;
        Country = restaurant.country;
        City = restaurant.city;
        District = restaurant.district;
        Twitter = restaurant.twitter;
        OpeningHours = restaurant.opening_hours;
        Console.WriteLine(Facebook);

        return Page();
    }

    public async Task<IActionResult> OnPostAsync()
    {

        string email = HttpContext.Session.GetString("Email");


        var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$email
                    SET {
                        facebook := <str>$facebook,
                        restaurant := <str>$restaurant,
                        instagram := <str>$instagram,
                        twitter := <str>$twitter,
                        phone_number := <str>$phone_number,
                        address := <str>$address,
                        opening_hours := <str>$opening_hours
                    }";
        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "address", Address },
                        { "email",email},
                        { "facebook", Facebook },
                        { "restaurant", Restaurant },
                        { "instagram",Instagram},
                        { "twitter", Twitter },
                        { "opening_hours", OpeningHours },
                         { "phone_number", PhoneNumber }
                    });

        return Page();
    }
    public async Task<IActionResult> OnPostCover()
    {
            string email = HttpContext.Session.GetString("Email");
       
            if (File != null && File.Length > 0)
            {

                // Save the uploaded file to the desired location
                var filePath = Path.Combine("wwwroot/Images/coverpics", File.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
            }
                var query = @"
                            UPDATE restaurant
                            FILTER restaurant.email = <str>$email
                            SET {
                         
                                cover_photo := <str>$cover_photo
                    
                            }";

            await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "email",email },
                        { "cover_photo", File.FileName }

                    });


            return Page();
        }

        public async Task<IActionResult> OnPostMain()
        {
            string email = HttpContext.Session.GetString("Email");

            if (File != null && File.Length > 0)
            {

                // Save the uploaded file to the desired location
                var filePath = Path.Combine("wwwroot/Images/coverpics", File.FileName);
                using (var fileStream = new FileStream(filePath, FileMode.Create))
                {
                    File.CopyTo(fileStream);
                }
            }
            var query = @"
                            UPDATE restaurant
                            FILTER restaurant.email = <str>$email
                            SET {
                         
                                main_photo := <str>$cover_photo
                    
                            }";

            await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "email",email },
                        { "cover_photo", File.FileName }

                    });


            return Page();
        }
}
