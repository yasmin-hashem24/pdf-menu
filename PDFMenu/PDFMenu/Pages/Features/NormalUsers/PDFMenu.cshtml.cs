using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using EdgeDB;
namespace PDFMenu.Pages.Features.NormalUsers;

public class PDFMenuModel : PageModel
{
    private readonly EdgeDBClient _edgeDbClient;
    [BindProperty]
    public string MenuName { get; set; }
    public PDFMenuModel(EdgeDBClient edgeDbClient)
    {
        _edgeDbClient = edgeDbClient;
    }
    public async Task OnGetAsync(string menu)
    {
        MenuName = menu;
    }
}
