namespace RazorTemplates.Models
{
    public class Country
    {
        public string CountryId { get; set; } = string.Empty;
        public string CountryName { get; set; } = string.Empty;
        public Game Game { get; set; } = null!;
        public Category Category { get; set; } = null!;
        public string CountryFlag { get; set; } = string.Empty;
    }
}
