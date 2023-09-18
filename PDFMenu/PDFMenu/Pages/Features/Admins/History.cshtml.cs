using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.Admins
{
    public class HistoryModel : PageModel
    {
        private readonly EdgeDBClient _edgeDbClient;

        [BindProperty]
        public List<history> MenuUploads { get; set; }
        public HistoryModel(EdgeDBClient edgeDbClient)
        {
            _edgeDbClient = edgeDbClient;
        }
        public async Task<IActionResult> OnGetAsync()
        {

                        string email = HttpContext.Session.GetString("Email");
                        var query = @"SELECT restaurant { menu_uploads :{menu_pdf, menu_upload_date},} FILTER restaurant.email = <str>$email LIMIT 1;";

                        var returned = await _edgeDbClient.QuerySingleAsync<RestaurantGot>(query, new Dictionary<string, object>
                        {
                            { "email", email }
                        });

                        if (returned != null)
                        {
                            MenuUploads = returned.menu_uploads;
                            MenuUploads.Reverse();
                return Page();
                        }
                        else
                        {

                            return RedirectToPage("/Admins/AdminPage");
                        }
        }

    }
}
