using System.Collections;
using SeleniumTest.EventsExpressTests.Models;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    public class EventForAdding : IEnumerable
    {
        private Event addEvent = new Event
        {
            Author = "Admin",
            Title = "add new event",
            Participants = "8",
            Description = "some new description",
            OnlineTitle = "Online meeting here",
            OnlinePath = "https://www.w3.org/TR/CSS21/selector.html%23id-selectors",
            Category = "Golf",
            Frequency = "6",
            DaysFrom = 3,
            DaysTo = 8,

        };
        private string email = "admin@gmail.com";
        private string password = "1qaz1qaz";
        private int eventOrder = 1;
        private string photoPath = "‪Desktop\\example.jpg";//path to photo, which you want to add

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { addEvent, email,password,eventOrder,photoPath };
        }
    }
}
