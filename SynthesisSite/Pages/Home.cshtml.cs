using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace SynthesisSite.Pages
{
    public class HomeModel : PageModel
    {

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Logged")== 0)
                return new RedirectToPageResult("Index");

            return Page();
        }
    }
}
