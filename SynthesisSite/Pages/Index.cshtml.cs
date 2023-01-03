using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Security.Claims;

namespace SynthesisSite.Pages
{
    public class IndexModel : PageModel
    {
        private readonly ILogger<IndexModel> _logger;

        [BindProperty]
        public DuelSysUser user { get; set; }

        public IndexModel(ILogger<IndexModel> logger)
        {
            _logger = logger;
        }

        public void OnGet()
        {
            if (!HttpContext.Session.Keys.Contains("username"))
            {
                HttpContext.Session.SetString("username", "");
                HttpContext.Session.SetString("password", "");
                HttpContext.Session.SetString("userType", "");
                HttpContext.Session.SetInt32("registeredID", -1);
            }

            HttpContext.Session.SetInt32("Logged", 0);
        }

        public IActionResult OnPost()
        {
            bool logged = user.TryLogin();
            bool connected = false;
            try
            {
                using (MySql.Data.MySqlClient.MySqlConnection con = new("Server=studmysql01.fhict.local;Uid=dbi486983;Database=dbi486983;Pwd=21092002;"))
                {
                    con.Open();
                    connected = con.Ping();
                }
            }
            catch { connected = false; }

            if (logged)
            {
                HttpContext.Session.SetString("userType", user.UserType);
                HttpContext.Session.SetInt32("registeredID", user.RegisteredTournamentID);
                if (user.RememberMe)
                {
                    HttpContext.Session.SetString("username", user.Username);
                    HttpContext.Session.SetString("password", user.Password);

                }
                else
                {
                    HttpContext.Session.Remove("username");
                    HttpContext.Session.Remove("password");
                }

                List<Claim> claims = new();
                claims.Add(new Claim("id", user.ID.ToString()));
                claims.Add(new Claim("name", user.Name));

                var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                HttpContext.SignInAsync(new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties
                {
                    ExpiresUtc = DateTime.UtcNow.AddMinutes(20)
                });
                HttpContext.Session.SetInt32("Logged", 1);

                return new RedirectToPageResult("Home");
            }
            else if (!connected)
            {
                HttpContext.Session.SetString("Error", "VPN");
                return Redirect("Error");
            }
            else if (!logged)
            {
                HttpContext.Session.SetString("Error", "Login");
                return Redirect("Error");
            }
            
            return Page();
        }

    }
}