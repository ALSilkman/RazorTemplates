namespace RazorTemplates.Models
{
    public class Filters
    {
        public Filters(string filterString)
        {
            filterString = filterString ?? "all-all";
            string[] filters = filterString.Split('-');

            Sprint = filters[0];
            StatusId = filters[1];
        }

        public string FilterString { get; }

        public string Sprint { get; }
        public string StatusId { get; }

        public bool HasSprint => Sprint.ToLower() != "all";
        public bool HasStatus => StatusId.ToLower() != "all";
    }
}
