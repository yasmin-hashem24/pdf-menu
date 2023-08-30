using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace PDFMenu.Pages.Features.Admins;

public class SignUpModel : PageModel
{
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
    public string[] Districts { get; set; } =
    new string[] {
        };

    public IActionResult OnPostReturn()
    {
        return RedirectToPage("/Index");
    }
}
