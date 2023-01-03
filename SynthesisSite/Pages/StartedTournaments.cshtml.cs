using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;

namespace SynthesisSite.Pages
{
    public class StartedTournamentsModel : PageModel
    {
        List<Tournament> availableTournaments = new();

        [BindProperty]
        public List<Tournament> Tournaments { get => availableTournaments; }
        [BindProperty]
        public int TournamentID { get; set; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Logged") == 0)
                return new RedirectToPageResult("Index");

            DisplayTournaments();
            return Page();
        }

        public void DisplayTournaments()
        {
            availableTournaments = TournamentTable.GetStartedTournaments();
        }
    }
}
