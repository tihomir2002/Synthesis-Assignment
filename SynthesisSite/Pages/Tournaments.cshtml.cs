using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using ClassLibrary;
using System;

namespace SynthesisSite.Pages
{
    public class TournamentsModel : PageModel
    {

        List<Tournament> availableTournaments = new();
        [BindProperty]
        public int TournamentID { get; set; }

        [BindProperty]
        public List<Tournament> Tournaments { get => availableTournaments; }

        public IActionResult OnGet()
        {
            if (HttpContext.Session.GetInt32("Logged") == 0)
                return new RedirectToPageResult("Index");
            DisplayTournaments();
            return Page();
        }


        public void DisplayTournaments()
        {
            if (HttpContext.Session.GetInt32("registeredID").HasValue)
                availableTournaments = new TournamentTable(HttpContext.Session.GetInt32("registeredID").Value).tournaments;
            else availableTournaments = new TournamentTable().tournaments;
        }

        public IActionResult OnPost()
        {
            HttpContext.Session.SetInt32("registeredID", TournamentID);
            int playerID = int.Parse(User.Claims.ToList()[0].Value);
            RegisterPlayer(playerID);    

            DisplayTournaments();
            return Page();
        }

        private void RegisterPlayer(int playerID)
        {
            PlayersAccessLayer playersAccessLayer = new PlayersAccessLayer(new Database());

            if (playersAccessLayer.PlayerExists(playerID))
            {
                //Registering player
                Player player = playersAccessLayer.GetPlayer(playerID);
                int prevTournamentID = player.TournamentID;
                player.TournamentID = TournamentID;
                playersAccessLayer.EditPlayer(player);

                //Unregistering
                TournamentAccessLayer tournamentAccessLayer = new(new Database());
                Tournament tournament = tournamentAccessLayer.GetTournament(prevTournamentID);
                //Console.WriteLine("Tournament before registering:" + tournament.RegisteredPlayers);
                tournament.RegisteredPlayers = playersAccessLayer.GetRegisteredPlayersCount(prevTournamentID);
                //Console.WriteLine("Player count:" + tournament.RegisteredPlayers);
                tournamentAccessLayer.EditTournament(tournament);

                //Registering for new one
                tournament = tournamentAccessLayer.GetTournament(TournamentID);
                //Console.WriteLine("Tournament before registering:" + tournament.RegisteredPlayers);
                tournament.RegisteredPlayers = playersAccessLayer.GetRegisteredPlayersCount(TournamentID);
                //Console.WriteLine("Player count:" + tournament.RegisteredPlayers);
                tournamentAccessLayer.EditTournament(tournament);
            }
            else
            {
                //Create the new player and add to the db
                string name = User.Claims.ToList()[1].Value;
                Player player = new(playerID, name, TournamentID);
                playersAccessLayer.AddPlayer(player);

                //Registering for new one
                TournamentAccessLayer tournamentAccessLayer = new(new Database());
                Tournament tournament = tournamentAccessLayer.GetTournament(TournamentID);
                tournament.RegisteredPlayers = playersAccessLayer.GetRegisteredPlayersCount(TournamentID);
                tournamentAccessLayer.EditTournament(tournament);
            }
        }
    }
}
