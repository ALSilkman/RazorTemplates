using Microsoft.AspNetCore.Http;
using RazorTemplates.Models;

namespace RazorTemplates.Models
{
    public class OlympicSession
    {
        private const string CountriesKey = "mycountries";
        private const string CountKey = "countrycount";
        private const string GameKey = "game";
        private const string CateKey = "cate";

        private ISession session {  get; set; }
        public OlympicSession(ISession session) => this.session = session;

        public void SetMyCountries(List<Country> countries)
        {
            session.SetObject(CountriesKey, countries);
            session.SetInt32(CountKey, countries.Count);
        }

        public List<Country> GetMyCountries() =>
            session.GetObject<List<Country>>(CountriesKey) ?? new List<Country>();
        public int? GetMyCountryCount() => session.GetInt32(CountKey);

        public void SetActiveGame(string activeGame) =>
            session.SetString(GameKey, activeGame);
        public string GetActiveGame() =>
            session.GetString(GameKey) ?? string.Empty;

        public void SetActiveCate(string activeCate) =>
            session.SetString(CateKey, activeCate);
        public string GetActiveCate() =>
            session.GetString(CateKey) ?? string.Empty;

        public void RemoveMyCountries()
        {
            session.Remove(CountriesKey);
            session.Remove(CountKey);
        }

    }
}
