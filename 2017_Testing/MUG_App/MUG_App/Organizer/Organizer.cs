namespace MUG_App.Organizer
{
    public class Organizer
    {
        public Organizer()
        {
            Name = string.Empty;
            Description = string.Empty;
            City = string.Empty;
            ImageUrl = string.Empty;
        }

        public string Name { get; set; }

        public string Description { get; set; }

        public string City { get; set; }

        public string ImageUrl { get; set; }

        public override string ToString() => Name;
    }
}