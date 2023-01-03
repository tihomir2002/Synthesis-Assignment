using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;

namespace SynthesisSite.Pages
{
    public class AllTournamentsModel : PageModel
    {
        public List<Tournament> Tournaments { get; set; }
        [BindProperty]
        public int SearchedID { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Logged") == 0)
                return new RedirectToPageResult("Index");

            Tournaments = new TournamentAccessLayer(new Database()).GetAllTournaments();
            return Page();
        }
        
        public IActionResult OnPost()
        {
            Tournaments = new TournamentAccessLayer(new Database()).GetAllTournaments();
            Tournaments.RemoveAll(Tournaments => Tournaments.ID != SearchedID);
            return Page();
        }
    }
}
