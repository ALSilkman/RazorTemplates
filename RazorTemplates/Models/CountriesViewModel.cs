namespace RazorTemplates.Models
{
    public class CountriesViewModel
    {
        public string ActiveGame { get; set; } = "all";
        public string ActiveCate { get; set; } = "all";

        public Country Country { get; set; } = new Country();

        public List<Country> Countries { get; set; } = new List<Country>();
        public List<Game> Games { get; set; } = new List<Game>();
        public List<Category> Categories { get; set; } = new List<Category>();

        public string CheckActiveGame(string g) => g.ToLower() == ActiveGame.ToLower() ? "active" : "";
        public string CheckActiveCate(string c) => c.ToLower() == ActiveCate.ToLower() ? "active" : "";
    }
}
