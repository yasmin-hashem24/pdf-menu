using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
using System.Web;

namespace PDFMenu.Pages.Features.Admins;

public class AdminPageModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;

    [BindProperty]
    public IFormFile File { get; set; }

    [BindProperty]
    public RestaurantGot RestaurantGot { get; set; }
    public AdminPageModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnGetAsync(string emaile)
    {
        var query = "SELECT restaurant { opening_hours,  menu_upload_date,menu_pdf,email,tags, password,restaurant,main_photo ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
                      "FILTER restaurant.email = <str>$email LIMIT 1;";

      
        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
    {
        { "email", emaile }
    });

        Console.WriteLine(returned.tags.Length);
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

    public IActionResult OnPost()
    {
        if (File != null && File.Length > 0)
        {

            // Save the uploaded file to the desired location
            var filePath = Path.Combine("wwwroot/Menus", File.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File.CopyTo(fileStream);
            }
        }

        // Optionally, you can perform additional processing or redirect to another page
        return Page();
    }
}


