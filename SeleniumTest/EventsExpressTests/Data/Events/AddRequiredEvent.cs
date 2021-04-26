using SeleniumTest.EventsExpressTests.Models;
using System.Collections;
using System.Collections.Generic;

namespace SeleniumTest.EventsExpressTests.Data.Events
{
    class AddRequiredEvent:IEnumerable
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
       
        private string photoPath = "‪Desktop\\example.jpg";//path to photo, which you want to add

        public IEnumerator GetEnumerator()
        {
            yield return new object[] { addEvent, photoPath };
        }
    }
}
