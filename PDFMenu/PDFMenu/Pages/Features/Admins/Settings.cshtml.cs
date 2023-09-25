using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Web;
using EdgeDB;
using SixLabors.ImageSharp;
using SixLabors.ImageSharp.Processing;
using SixLabors.ImageSharp.Formats.Png;
using SixLabors.ImageSharp.Formats.Jpeg;
using SixLabors.ImageSharp.Formats.Gif;
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
    public string[] tags { get; set; }


    [BindProperty]
    public IFormFile File { get; set; }

    [BindProperty]

    public string tag0 { get; set; }
    [BindProperty]

    public string tag1 { get; set; }
    [BindProperty]

    public string tag2 { get; set; }

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
    public string[] Cities { get; set; } = new string[] {};

    [BindProperty]
    public string[] Districts { get; set; } = new string[] {};

    public bool hideCover = false;
    public bool hideMain = false;
    public bool hideData = false;
    private readonly EdgeDBClient _edgeDbClient;
    public SettingsModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
        
    }
    public async Task<IActionResult> OnGetAsync(bool cover, bool main, bool data)
    {
        hideCover = cover;
        hideMain = main;
        hideData = data;
        string email = HttpContext.Session.GetString("Email");
        var query = "SELECT restaurant {tags,facebook,restaurant,phone_number,instagram,twitter,country,city,district,address,opening_hours} " +
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
        tags = restaurant.tags;
        tag0 = tags[0];
        tag1 = tags[1];
        tag2 = tags[2];
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

      
        var query1= "SELECT restaurant {tags,facebook,restaurant,phone_number,instagram,twitter,country,city,district,address,opening_hours} " +
                       "FILTER restaurant.email = <str>$email LIMIT 1;";

        var parameters = new Dictionary<string, object>
        {
                { "email", email }
        };

        var restaurant = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query1, parameters);

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
        tags = restaurant.tags;
        tag0 = tags[0];
        tag1 = tags[1];
        tag2 = tags[2];
        return RedirectToPage("Settings", new { cover = false, main = false , data=true });
    }
    public async Task<IActionResult> OnPostCover()
    {
        Console.WriteLine("INSIDE COVER");
            string email = HttpContext.Session.GetString("Email");
       
            if (File != null && File.Length > 0)
            {

            var filePath = Path.Combine("wwwroot/Images/coverpics", File.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                
                using (Image image = Image.Load(File.OpenReadStream()))
                {
                    int width = image.Width / 2;
                    int height = image.Height / 2;
                    image.Mutate(x => x.Resize(width, height, KnownResamplers.Lanczos3));

                   
                    image.Save(fileStream, new PngEncoder()); 
                }
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
        var query1 = "SELECT restaurant {tags,facebook,restaurant,phone_number,instagram,twitter,country,city,district,address,opening_hours} " +
                      "FILTER restaurant.email = <str>$email LIMIT 1;";

        var parameters = new Dictionary<string, object>
        {
                { "email", email }
        };

        var restaurant = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query1, parameters);

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
        tags = restaurant.tags;
        tag0 = tags[0];
        tag1 = tags[1];
        tag2 = tags[2];
        return RedirectToPage("Settings", new { cover = false, main = true, data = false });
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
                using (Image image = Image.Load(File.OpenReadStream()))
                {
                    int width = image.Width / 2;
                    int height = image.Height / 2;
                    image.Mutate(x => x.Resize(width, height, KnownResamplers.Lanczos3));


                    image.Save(fileStream, new PngEncoder());
                }
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
        var query1 = "SELECT restaurant {tags,facebook,restaurant,phone_number,instagram,twitter,country,city,district,address,opening_hours} " +
                      "FILTER restaurant.email = <str>$email LIMIT 1;";

        var parameters = new Dictionary<string, object>
        {
                { "email", email }
        };

        var restaurant = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query1, parameters);

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
        tags = restaurant.tags;
        tag0 = tags[0];
        tag1 = tags[1];
        tag2 = tags[2];
        return RedirectToPage("Settings", new { cover = true, main = false, data = false });
    }
}
