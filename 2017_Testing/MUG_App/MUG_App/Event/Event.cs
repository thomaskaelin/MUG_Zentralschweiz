namespace MUG_App.Event
{
    public class Event
    {
        public Event()
        {
            Title = string.Empty;
            RSVPCount = 0;
            Description = string.Empty;
        }

        public string Title { get; set; }

        public string Description { get; set; }

        public int RSVPCount { get; set; }

        public override string ToString() => $"{Title}: {Description}";
    }
}