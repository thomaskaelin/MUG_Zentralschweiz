namespace MUG_App.Group
{
    public class Group
    {
        public Group()
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
    }
}