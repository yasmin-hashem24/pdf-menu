using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Identity;
using EdgeDB;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Options;
using MimeKit;
namespace PDFMenu.Pages.Features.NormalUsers;

public class ResetPasswordModel : PageModel
{
    

    [BindProperty]

    public string Email { get; set; }

    public bool hide = false;

    private readonly EdgeDBClient _edgeDbClient;
    private readonly EmailSettings _emailSettings;
    public ResetPasswordModel(EdgeDBClient edgeDbClient, IOptions<EmailSettings> emailSettings)
    {
        _edgeDbClient = edgeDbClient;
        _emailSettings = emailSettings.Value;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        hide = true;

        var passwordHasher = new PasswordHasher<string>();
        string hashedPassword = passwordHasher.HashPassword(null, "amazingpapss23");

        var message = new MimeMessage();
        message.From.Add(new MailboxAddress("DineDocs", _emailSettings.Email));
        message.To.Add(new MailboxAddress("dine", Email));
        message.Subject = "Confirmation Email";
        var bodyText = "Thank you for signing up. Your account has been successfully created. Your new password is: " + hashedPassword;

        var query = @"
                    UPDATE restaurant
                    FILTER restaurant.email = <str>$email
                    SET {
                          
                        password := <str>$newpassword
                        
                        
                    
                    }";
        await _edgeDbClient.ExecuteAsync(query, new Dictionary<string, object?>
                {
                    { "newpassword",hashedPassword },
                    
                     { "email",Email }

                });
        message.Body = new TextPart("plain")
        {
            Text = bodyText
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
