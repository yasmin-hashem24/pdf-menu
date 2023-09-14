using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
using Microsoft.AspNetCore.Session;
namespace PDFMenu.Pages.Features.NormalUsers;

public class LoginModel : PageModel
{

    [BindProperty]
    public RestaurantInput res { get; set; }

    private readonly EdgeDBClient _edgeDbClient;
    public LoginModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        string email = res.Email;
       
        HttpContext.Session.SetString("Email", email);

        string password = res.Password;
    
        var query = "SELECT restaurant {email, password,restaurant ,phone_number,cover_photo,facebook,instagram,twitter,country,address,city,district,rating} " +
                       "FILTER restaurant.email = <str>$email AND restaurant.password = <str>$password LIMIT 1;";

        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
        {
            { "email", email },
            { "password", password }
        });
       
        if (returned != null)
        {
          

            return RedirectToPage("/Features/Admins/AdminPage", new { emaile = email });
        }
        else
        {
            Console.WriteLine("None");
            ModelState.AddModelError(string.Empty, "Invalid email or password");
            return Page();
        }
    }
}


