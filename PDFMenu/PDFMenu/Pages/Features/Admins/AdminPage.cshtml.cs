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
        var query = "SELECT restaurant { opening_hours, menu_upload_date,menu_pdf,email,tags, password,restaurant,main_photo ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
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

    public async Task<IActionResult> OnPostAsync()
    {
        var email = Request.Form.FirstOrDefault(x => x.Key == "email").Value.FirstOrDefault(); ;
        Console.WriteLine(email);
        if (File != null && File.Length > 0)
        {

            // Save the uploaded file to the desired location
            var filePath = Path.Combine("wwwroot/Menus", File.FileName);
            using (var fileStream = new FileStream(filePath, FileMode.Create))
            {
                File.CopyTo(fileStream);
            }
        }
        var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$email
                    SET {
                        menu_upload_date := <datetime>$menu_upload_date,
                        menu_pdf := <str>$menu_pdf
                    
                    }";
        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "email",email },
                        { "menu_upload_date", DateTime.Now },
                        { "menu_pdf", File.FileName }
                       
                    });


        return RedirectToPage("AdminPage", new { emaile = email });
    }
}


