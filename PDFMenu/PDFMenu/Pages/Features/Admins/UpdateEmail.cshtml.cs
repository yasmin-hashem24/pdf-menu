using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins
{
    public class UpdateEmailModel : PageModel
    {
        [BindProperty]
        public string CurrentEmail { get; set; }

        [BindProperty]
        public string Password { get; set; }

        [BindProperty]
        public string NewEmail { get; set; }

        public bool hide = false;

        private readonly EdgeDBClient _edgeDbClient;
     
        public UpdateEmailModel(EdgeDBClient edgeDbClient)
        {
            _edgeDbClient = edgeDbClient;
           
        }
        public async Task<IActionResult> OnPostAsync()
        {
            HttpContext.Session.SetString("Email", NewEmail);
            hide = true;
            string email = CurrentEmail;
            string password = Password;
            string newemail = NewEmail;
            var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$email AND restaurant.password = <str>$password
                    SET {
                          
                        email := <str>$new_email
                        
                        
                    
            }";
            await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                    {
                        { "email",email },
                         { "password",password },
                         { "new_email",newemail }

            });
            return Page();
        }
    }
}
