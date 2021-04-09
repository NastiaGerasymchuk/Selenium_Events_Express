using SeleniumTest.EventsExpressTests.Enum;

namespace SeleniumTest.EventsExpressTests.Models
{
    public class Event
    {
        public string Author { get; set; }
        public string Title { get; set; }
        public string Participants { get; set; }
        public string Description { get; set; }
        public string OnlineTitle { get; set; }
        public string OnlinePath { get; set; }
        public string Category { get; set; }
        public string DateFrom { get; set; }
        public string DateTo { get; set; }
        public string FullDate { get; set; }
        public string HeaderVisitor { get; set; }
        public Protection Protection { get; set; }
       
    }
}
