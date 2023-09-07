using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EdgeDB;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
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
    private readonly EmailSettings _emailSettings;
    public SignUpModel(EdgeDBClient edgeDbClient, IOptions<EmailSettings> emailSettings)
    {
        _edgeDbClient = edgeDbClient;
        _emailSettings = emailSettings.Value;
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


        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("DineDocs", _emailSettings.Email));
        message.To.Add(new MailboxAddress("dine", restaurantIn.Email));
        message.Subject = "Confirmation Email";
        message.Body = new TextPart("plain")
        {
            Text = "Thank you for signing up. Your account has been successfully created."
        };

        using (var client = new SmtpClient())
        {
            await client.ConnectAsync(_emailSettings.Host, _emailSettings.Port, SecureSocketOptions.StartTls);
            await client.AuthenticateAsync(_emailSettings.Email, _emailSettings.Password);
            await client.SendAsync(message);
            await client.DisconnectAsync(true);
        }
        return Page();
    }
  
}

